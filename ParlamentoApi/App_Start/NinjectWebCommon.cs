using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ParlamentoApi;
using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoAplicacao.ServicosApp;
using ParlamentoAplicacao.ServicosApp.Parlamentares;
using ParlamentoDados.Repositorios;
using ParlamentoDados.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;
using ParlamentoDominio.Servicos;
using ParlamentoDominio.Servicos.Parlamentares;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Parlamentares;
using ParlamentoTarefas.ServicosExternos;
using ParlamentoTarefas.Tarefas.Parlamentares;
using System;
using System.Web;

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

            // Tarefas
            kernel.Bind(typeof(IBaseServicosExternos)).To(typeof(BaseServicosExternos));
            kernel.Bind<IExemplosServicosExternos>().To<ExemplosServicosExternos>();
            kernel.Bind<ISenadoServicosExternos>().To<SenadoServicosExternos>();

            kernel.Bind<IAtualizarSenadoresTarefa>().To<AtualizarSenadoresTarefa>();

            // Aplicacao
            kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            kernel.Bind<IExemplosServicosApp>().To<ExemplosServicosApp>();
            kernel.Bind<IExerciciosServicosApp>().To<ExerciciosServicosApp>();
            kernel.Bind<IIdentificacoesServicosApp>().To<IdentificacoesServicosApp>();
            kernel.Bind<ILegislaturasServicosApp>().To<LegislaturasServicosApp>();
            kernel.Bind<IMandatosServicosApp>().To<MandatosServicosApp>();
            kernel.Bind<IParlamentaresServicosApp>().To<ParlamentaresServicosApp>();

            // Dominio
            kernel.Bind(typeof(IBaseServicos<>)).To(typeof(BaseServicos<>));
            kernel.Bind<IExemplosServicos>().To<ExemplosServicos>();
            kernel.Bind<IExerciciosServicos>().To<ExerciciosServicos>();
            kernel.Bind<IIdentificacoesServicos>().To<IdentificacoesServicos>();
            kernel.Bind<ILegislaturasServicos>().To<LegislaturasServicos>();
            kernel.Bind<IMandatosServicos>().To<MandatosServicos>();
            kernel.Bind<IParlamentaresServicos>().To<ParlamentaresServicos>();

            // Infra
            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            kernel.Bind<IExemplosRepositorio>().To<ExemplosRepositorio>();
            kernel.Bind<IExerciciosRepositorio>().To<ExerciciosRepositorio>();
            kernel.Bind<IIdentificacoesRepositorio>().To<IdentificacoesRepositorio>();
            kernel.Bind<ILegislaturasRepositorio>().To<LegislaturasRepositorio>();
            kernel.Bind<IMandatosRepositorio>().To<MandatosRepositorio>();
            kernel.Bind<IParlamentaresRepositorio>().To<ParlamentaresRepositorio>();
        }
    }
}
