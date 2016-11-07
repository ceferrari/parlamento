using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ParlamentoApi;
using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoAplicacao.ServicosApp;
using ParlamentoAplicacao.ServicosApp.Senado;
using ParlamentoDados.Repositorios;
using ParlamentoDados.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos;
using ParlamentoDominio.Interfaces.Servicos.Senado;
using ParlamentoDominio.Servicos;
using ParlamentoDominio.Servicos.Senado;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

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
            TarefasConfig.Ninject(kernel);

            // Aplicacao
            kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            kernel.Bind<ILegislaturasServicosApp>().To<LegislaturasServicosApp>();
            kernel.Bind<IMateriasAssuntosServicosApp>().To<MateriasAssuntosServicosApp>();
            kernel.Bind<IMateriasServicosApp>().To<MateriasServicosApp>();
            kernel.Bind<IMateriasSubtiposServicosApp>().To<MateriasSubtiposServicosApp>();
            kernel.Bind<ISenadoresServicosApp>().To<SenadoresServicosApp>();
            kernel.Bind<IVotacoesServicosApp>().To<VotacoesServicosApp>();
            kernel.Bind<IVotosServicosApp>().To<VotosServicosApp>();

            kernel.Bind<IUsuariosServicosApp>().To<UsuariosServicosApp>();

            // Dominio
            kernel.Bind(typeof(IBaseServicos<>)).To(typeof(BaseServicos<>));
            kernel.Bind<ILegislaturasServicos>().To<LegislaturasServicos>();
            kernel.Bind<IMateriasAssuntosServicos>().To<MateriasAssuntosServicos>();
            kernel.Bind<IMateriasServicos>().To<MateriasServicos>();
            kernel.Bind<IMateriasSubtiposServicos>().To<MateriasSubtiposServicos>();
            kernel.Bind<ISenadoresServicos>().To<SenadoresServicos>();
            kernel.Bind<IVotacoesServicos>().To<VotacoesServicos>();
            kernel.Bind<IVotosServicos>().To<VotosServicos>();

            kernel.Bind<IUsuariosServicos>().To<UsuariosServicos>();

            // Infra
            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            kernel.Bind<ILegislaturasRepositorio>().To<LegislaturasRepositorio>();
            kernel.Bind<IMateriasAssuntosRepositorio>().To<MateriasAssuntosRepositorio>();
            kernel.Bind<IMateriasRepositorio>().To<MateriasRepositorio>();
            kernel.Bind<IMateriasSubtiposRepositorio>().To<MateriasSubtiposRepositorio>();
            kernel.Bind<ISenadoresRepositorio>().To<SenadoresRepositorio>();
            kernel.Bind<IVotacoesRepositorio>().To<VotacoesRepositorio>();
            kernel.Bind<IVotosRepositorio>().To<VotosRepositorio>();

            kernel.Bind<IUsuariosRepositorio>().To<UsuariosRepositorio>();
        }
    }
}