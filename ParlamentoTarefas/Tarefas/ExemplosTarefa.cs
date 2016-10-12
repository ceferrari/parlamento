using Hangfire;
using Ninject;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas;

namespace ParlamentoTarefas.Tarefas
{
    public class ExemplosTarefa : NinjectJobActivator, IExemplosTarefa
    {
        private readonly IExemplosServicosExternos _exemplos;

        public ExemplosTarefa(IExemplosServicosExternos exemplos)
            : base(new StandardKernel())
        {
            _exemplos = exemplos;
        }

        public void Executar()
        {
            var listaExemplos = _exemplos.ListarExemplos();
        }
    }
}