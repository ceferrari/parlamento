using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System.Collections.Generic;
using System.Linq;

namespace ParlamentoTarefas.Tarefas.Senado
{
    public class AtualizarSenadoresTarefa : NinjectJobActivator, IAtualizarSenadoresTarefa
    {
        private readonly ISenadoServicosExternos _senado;
        private readonly ISenadoresServicosApp _senadores;
        private readonly ILegislaturasServicosApp _legislaturas;

        public AtualizarSenadoresTarefa(ISenadoServicosExternos senado, ISenadoresServicosApp senadores, ILegislaturasServicosApp legislaturas)
            : base(new StandardKernel())
        {
            _senado = senado;
            _senadores = senadores;
            _legislaturas = legislaturas;
        }

        public void Executar()
        {
            var legislaturaAtual = _legislaturas.ObterAtual();
            var listaSenadoresLegislaturaAtual = _senado.ListarSenadoresPorLegislatura(legislaturaAtual.Codigo.ToString()).Conteudo;
            var listaCodigosSenadoresLegislaturaAtual = listaSenadoresLegislaturaAtual.ListaParlamentarLegislatura.Parlamentares.Parlamentar
                .Select(x => x.IdentificacaoParlamentar.CodigoParlamentar);

            var listaSenadoresEmExercicioViewModel = _senado.ListarSenadoresEmExercicio().Conteudo;
            var listaCodigosSenadoresEmExercicio = listaSenadoresEmExercicioViewModel.ListaParlamentarEmExercicio.Parlamentares.Parlamentar
                .Select(x => x.IdentificacaoParlamentar.CodigoParlamentar);

            var listaSenadoresEntidades = new List<Senador>();

            foreach (var codigoSenador in listaCodigosSenadoresEmExercicio)
            {
                var senadorViewModel = _senado.ObterSenadorPorCodigo(codigoSenador).Conteudo;
                var senadorEntidade = Mapper.Map<Senador>(senadorViewModel);

                var parlamentarViewModel = _senado.ObterParlamentarPorCodigo(codigoSenador).Conteudo;
                senadorEntidade.CidadeNascimento = parlamentarViewModel.parlamentar.nomeCidadeNatural;
                senadorEntidade.EmExercicio = listaCodigosSenadoresEmExercicio.Contains(codigoSenador);

                listaSenadoresEntidades.Add(senadorEntidade);
            }

            _senadores.MesclarEmMassa(listaSenadoresEntidades);
        }
    }
}