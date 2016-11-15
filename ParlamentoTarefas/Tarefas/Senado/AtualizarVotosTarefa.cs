using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoRecursos.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParlamentoTarefas.Tarefas.Senado
{
    public class AtualizarVotosTarefa : NinjectJobActivator, IAtualizarVotosTarefa
    {
        private readonly ISenadoServicosExternos _senado;
        private readonly IMateriasServicosApp _materiasSvc;
        private readonly IVotosServicosApp _votosSvc;

        public AtualizarVotosTarefa(ISenadoServicosExternos senado, IMateriasServicosApp materiasSvc, IVotosServicosApp votosSvc)
            : base(new StandardKernel())
        {
            _senado = senado;
            _materiasSvc = materiasSvc;
            _votosSvc = votosSvc;
        }

        public void Executar()
        {
            var listaSenadoresViewModel = _senado.ListarSenadoresEmExercicio().Conteudo.ListaParlamentarEmExercicio.Parlamentares.Parlamentar;
            var listaCodigosSenadores = listaSenadoresViewModel.Select(x => x.IdentificacaoParlamentar.CodigoParlamentar);

            var listaVotosEntidades = new List<Voto>();

            foreach (var codigoSenador in listaCodigosSenadores)
            {
                var votacoesViewModel = _senado.ObterVotacaoPorCodigo(codigoSenador).Conteudo;
                var aux = votacoesViewModel.VotacaoParlamentar.Parlamentar.Votacoes.Votacao;
                var votos = Mapper.Map<List<Voto>>(aux);

                var codigoSenadorInt = Convert.ToInt32(codigoSenador);
                foreach (var voto in votos)
                {
                    voto.CodigoSenador = codigoSenadorInt;
                }

                listaVotosEntidades.AddRange(votos);
            }

            var listaMateriasEntidades = _materiasSvc.Listar().ToList();
            var listaCodigosMaterias = listaMateriasEntidades.Select(x => x.Codigo).ToList();

            listaVotosEntidades.RemoveAll(x => !listaCodigosMaterias.Contains(x.CodigoMateria));

            listaVotosEntidades = listaVotosEntidades.GroupBy(x => new {x.CodigoSenador, x.CodigoMateria, x.CodigoSessao}).Select(x => x.First()).ToList();

            _votosSvc.MesclarEmMassa(listaVotosEntidades);
        }
    }
}