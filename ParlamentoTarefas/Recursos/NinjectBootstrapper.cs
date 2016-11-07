using Ninject;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using ParlamentoTarefas.Tarefas.Senado;

namespace ParlamentoTarefas.Recursos
{
    public class NinjectBootstrapper
    {
        public static void RegisterServices(IKernel kernel)
        {
            ParlamentoRecursos.Recursos.NinjectBootstrapper.RegisterServices(kernel);

            // Tarefas
            kernel.Bind<IAtualizarLegislaturasTarefa>().To<AtualizarLegislaturasTarefa>();
            kernel.Bind<IAtualizarMateriasTarefa>().To<AtualizarMateriasTarefa>();
            kernel.Bind<IAtualizarSenadoresTarefa>().To<AtualizarSenadoresTarefa>();
            kernel.Bind<IAtualizarVotosTarefa>().To<AtualizarVotosTarefa>();
        }
    }
}