using Ninject;
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

namespace ParlamentoTarefas
{
    public class NinjectBootstrapper
    {
        public static void RegisterServices(IKernel kernel)
        {
            //GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            //ParlamentoTransversal.NinjectBootstrapper.RegisterServices(kernel);

            // Tarefas
            kernel.Bind(typeof(IBaseServicosExternos)).To(typeof(BaseServicosExternos));
            kernel.Bind<ISenadoServicosExternos>().To<SenadoServicosExternos>();

            kernel.Bind<IAtualizarSenadoresTarefa>().To<AtualizarSenadoresTarefa>();

            // Aplicacao
            kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            kernel.Bind<IExerciciosServicosApp>().To<ExerciciosServicosApp>();
            kernel.Bind<IIdentificacoesServicosApp>().To<IdentificacoesServicosApp>();
            kernel.Bind<ILegislaturasServicosApp>().To<LegislaturasServicosApp>();
            kernel.Bind<IMandatosServicosApp>().To<MandatosServicosApp>();
            kernel.Bind<IParlamentaresServicosApp>().To<ParlamentaresServicosApp>();

            // Dominio
            kernel.Bind(typeof(IBaseServicos<>)).To(typeof(BaseServicos<>));
            kernel.Bind<IExerciciosServicos>().To<ExerciciosServicos>();
            kernel.Bind<IIdentificacoesServicos>().To<IdentificacoesServicos>();
            kernel.Bind<ILegislaturasServicos>().To<LegislaturasServicos>();
            kernel.Bind<IMandatosServicos>().To<MandatosServicos>();
            kernel.Bind<IParlamentaresServicos>().To<ParlamentaresServicos>();

            // Infra
            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            kernel.Bind<IExerciciosRepositorio>().To<ExerciciosRepositorio>();
            kernel.Bind<IIdentificacoesRepositorio>().To<IdentificacoesRepositorio>();
            kernel.Bind<ILegislaturasRepositorio>().To<LegislaturasRepositorio>();
            kernel.Bind<IMandatosRepositorio>().To<MandatosRepositorio>();
            kernel.Bind<IParlamentaresRepositorio>().To<ParlamentaresRepositorio>();
        }
    }
}