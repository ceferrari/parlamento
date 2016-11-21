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
using System.Net;

namespace ParlamentoTarefas.Tarefas.Senado
{
    public class AtualizarVotosTarefa : NinjectJobActivator, IAtualizarVotosTarefa
    {
        private readonly ISenadoServicosExternos _senado;
        private readonly IMateriasServicosApp _materiasSvc;
        private readonly ISenadoresServicosApp _senadoresSvc;
        private readonly IVotosServicosApp _votosSvc;

        public AtualizarVotosTarefa(ISenadoServicosExternos senado, ISenadoresServicosApp senadoresSvc, IMateriasServicosApp materiasSvc, IVotosServicosApp votosSvc)
            : base(new StandardKernel())
        {
            _senado = senado;
            _materiasSvc = materiasSvc;
            _senadoresSvc = senadoresSvc;
            _votosSvc = votosSvc;
        }

        public void Executar()
        {
            var codigosSenadores = _senadoresSvc.Listar().Select(x => x.Codigo);

            var votos = new List<Voto>();

            foreach (var codigoSenador in codigosSenadores)
            {
                var votacoes = _senado.ObterVotacaoPorCodigo(codigoSenador);
                while (votacoes.CodigoStatus != HttpStatusCode.OK)
                {
                    votacoes = _senado.ObterVotacaoPorCodigo(codigoSenador);
                }
                var votosEntidades = Mapper.Map<List<Voto>>(votacoes.Conteudo.VotacaoParlamentar.Parlamentar.Votacoes.Votacao);

                foreach (var votoEntidade in votosEntidades)
                {
                    votoEntidade.CodigoSenador = codigoSenador;
                }
                votos.AddRange(votosEntidades);
            }
            
            var codigosMaterias = _materiasSvc.Listar().Select(x => x.Codigo);

            votos.RemoveAll(x => !codigosMaterias.Contains(x.CodigoMateria));
            votos = votos.GroupBy(x => new {x.CodigoSenador, x.CodigoMateria, x.CodigoSessao}).Select(x => x.First()).ToList();

            _votosSvc.MesclarEmMassa(votos);
        }
    }
}