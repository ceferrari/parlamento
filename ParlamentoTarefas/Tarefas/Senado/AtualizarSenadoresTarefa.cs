using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoRecursos.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            //var legislaturaAtual = _legislaturas.ObterAtual();
            //var senadoresLegislaturaAtual = _senado.ListarSenadoresPorLegislatura(legislaturaAtual.Codigo.ToString());
            //while (senadoresLegislaturaAtual.CodigoStatus != HttpStatusCode.OK)
            //{
            //    senadoresLegislaturaAtual = _senado.ListarSenadoresPorLegislatura(legislaturaAtual.Codigo.ToString());
            //}
            //var codigosSenadoresLegislaturaAtual = senadoresLegislaturaAtual.Conteudo.ListaParlamentarLegislatura.Parlamentares.Parlamentar.Select(x => x.IdentificacaoParlamentar.CodigoParlamentar);

            var senadoresEmExercicio = _senado.ListarSenadoresEmExercicio();
            while (senadoresEmExercicio.CodigoStatus != HttpStatusCode.OK)
            {
                senadoresEmExercicio = _senado.ListarSenadoresEmExercicio();
            }
            var codigosSenadoresEmExercicio = senadoresEmExercicio.Conteudo.ListaParlamentarEmExercicio.Parlamentares.Parlamentar.Select(x => x.IdentificacaoParlamentar.CodigoParlamentar);

            var senadores = new List<Senador>();

            foreach (var codigoSenadorEmExercicio in codigosSenadoresEmExercicio)
            {
                var senador = _senado.ObterSenadorPorCodigo(codigoSenadorEmExercicio);
                while (senador.CodigoStatus != HttpStatusCode.OK)
                {
                    senador = _senado.ObterSenadorPorCodigo(codigoSenadorEmExercicio);
                }
                var senadorEntidade = Mapper.Map<Senador>(senador.Conteudo);

                var parlamentar = _senado.ObterParlamentarPorCodigo(codigoSenadorEmExercicio);
                while (parlamentar.CodigoStatus != HttpStatusCode.OK)
                {
                    parlamentar = _senado.ObterParlamentarPorCodigo(codigoSenadorEmExercicio);
                }
                senadorEntidade.CidadeNascimento = parlamentar.Conteudo.parlamentar.nomeCidadeNatural;
                senadorEntidade.EmExercicio = codigosSenadoresEmExercicio.Contains(codigoSenadorEmExercicio);

                senadores.Add(senadorEntidade);
            }

            _senadores.MesclarEmMassa(senadores);
        }
    }
}