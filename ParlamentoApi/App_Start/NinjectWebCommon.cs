using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ParlamentoApi;
using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoAplicacao.ServicosApp;
using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Servicos;
using ParlamentoDominio.Servicos;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.ServicosExternos;
using ParlamentoDados.Repositorios;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace ParlamentoApi
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            //ParlamentoTransversal.NinjectBootstrapper.RegisterServices(kernel);

            // Aplicacao
            kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            kernel.Bind<IExemplosServicosApp>().To<ExemplosServicosApp>();

            kernel.Bind(typeof(IBaseServicosExternos)).To(typeof(BaseServicosExternos));
            kernel.Bind<IExemplosServicosExternos>().To<ExemplosServicosExternos>();

            // Dominio
            kernel.Bind(typeof(IBaseServicos<>)).To(typeof(BaseServicos<>));
            kernel.Bind<IExemplosServicos>().To<ExemplosServicos>();

            // Infra
            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            kernel.Bind<IExemplosRepositorio>().To<ExemplosRepositorio>();
        }
    }
}
