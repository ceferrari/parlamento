using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoAplicacao.ServicosApp.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos;
using ParlamentoDominio.Servicos;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.ServicosExternos;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ParlamentoMvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ParlamentoMvc.App_Start.NinjectWebCommon), "Stop")]

namespace ParlamentoMvc.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ParlamentoDados.Repositorios;
    using ParlamentoDominio.Interfaces.Repositorios;
    using ParlamentoAplicacao.ServicosApp;

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
            // Aplicacao
            kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            kernel.Bind<IExerciciosServicosApp>().To<ExerciciosServicosApp>();

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
