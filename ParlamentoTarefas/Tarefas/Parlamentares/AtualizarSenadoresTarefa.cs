using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Parlamentares;
using System.Collections.Generic;

namespace ParlamentoTarefas.Tarefas.Parlamentares
{
    public class AtualizarSenadoresTarefa : NinjectJobActivator, IAtualizarSenadoresTarefa
    {
        private readonly ISenadoServicosExternos _senado;
        private readonly IParlamentaresServicosApp _parlamentares;

        public AtualizarSenadoresTarefa(ISenadoServicosExternos senado, IParlamentaresServicosApp parlamentares)
            : base(new StandardKernel())
        {
            _senado = senado;
            _parlamentares = parlamentares;
        }

        public void Executar()
        {
            var senadoresViewModel = _senado.ListarSenadores().Conteudo.ListaParlamentarEmExercicio.Parlamentares.Parlamentar;
            var senadoresEntidade = Mapper.Map<List<Parlamentar>>(senadoresViewModel);

            _parlamentares.MesclarEmMassa(senadoresEntidade);
        }
    }
}