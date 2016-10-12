using Ninject;

namespace ParlamentoTransversal
{
    public class NinjectBootstrapper
    {
        //public static void Main(string[] args)
        //{
        //    var kernel = new StandardKernel();
        //    try
        //    {
        //        RegisterServices(kernel);
        //    }
        //    catch
        //    {
        //        kernel.Dispose();
        //        throw;
        //    }
        //}

        public static void RegisterServices(IKernel kernel)
        {
            // Api

            // Crons
            //kernel.Bind<IExemplosTarefa>().To<ExemplosTarefa>();

            // Aplicacao
            //kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            //kernel.Bind<IExemplosServicosApp>().To<ExemplosServicosApp>();

            //kernel.Bind(typeof(IBaseServicosExternos)).To(typeof(BaseServicosExternos));
            //kernel.Bind<IExemplosServicosExternos>().To<ExemplosServicosExternos>();

            //// Dominio
            //kernel.Bind(typeof(IBaseServicos<>)).To(typeof(BaseServicos<>));
            //kernel.Bind<IExemplosServicos>().To<ExemplosServicos>();

            //// Infra
            //kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            //kernel.Bind<IExemplosRepositorio>().To<ExemplosRepositorio>();
        }
    }
}