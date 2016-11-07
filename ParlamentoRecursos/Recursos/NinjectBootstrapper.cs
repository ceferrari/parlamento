using Ninject;
using ParlamentoRecursos.Interfaces.ServicosExternos;
using ParlamentoRecursos.ServicosExternos;

namespace ParlamentoRecursos.Recursos
{
    public class NinjectBootstrapper
    {
        public static void RegisterServices(IKernel kernel)
        {
            // Tarefas
            kernel.Bind(typeof(IBaseServicosExternos)).To(typeof(BaseServicosExternos));
            kernel.Bind<ISenadoServicosExternos>().To<SenadoServicosExternos>();
        }
    }
}