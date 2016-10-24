using Ninject;
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
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using ParlamentoTarefas.ServicosExternos;
using ParlamentoTarefas.Tarefas.Senado;

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

            kernel.Bind<IAtualizarLegislaturasTarefa>().To<AtualizarLegislaturasTarefa>();
            kernel.Bind<IAtualizarMateriasTarefa>().To<AtualizarMateriasTarefa>();
            kernel.Bind<IAtualizarSenadoresTarefa>().To<AtualizarSenadoresTarefa>();
            kernel.Bind<IAtualizarVotosTarefa>().To<AtualizarVotosTarefa>();

            // Aplicacao
            kernel.Bind(typeof(IBaseServicosApp<>)).To(typeof(BaseServicosApp<>));
            kernel.Bind<ILegislaturasServicosApp>().To<LegislaturasServicosApp>();
            kernel.Bind<IMateriasAssuntosServicosApp>().To<MateriasAssuntosServicosApp>();
            kernel.Bind<IMateriasServicosApp>().To<MateriasServicosApp>();
            kernel.Bind<IMateriasSubtiposServicosApp>().To<MateriasSubtiposServicosApp>();
            kernel.Bind<ISenadoresServicosApp>().To<SenadoresServicosApp>();
            kernel.Bind<IVotacoesServicosApp>().To<VotacoesServicosApp>();
            kernel.Bind<IVotosServicosApp>().To<VotosServicosApp>();

            // Dominio
            kernel.Bind(typeof(IBaseServicos<>)).To(typeof(BaseServicos<>));
            kernel.Bind<ILegislaturasServicos>().To<LegislaturasServicos>();
            kernel.Bind<IMateriasAssuntosServicos>().To<MateriasAssuntosServicos>();
            kernel.Bind<IMateriasServicos>().To<MateriasServicos>();
            kernel.Bind<IMateriasSubtiposServicos>().To<MateriasSubtiposServicos>();
            kernel.Bind<ISenadoresServicos>().To<SenadoresServicos>();
            kernel.Bind<IVotacoesServicos>().To<VotacoesServicos>();
            kernel.Bind<IVotosServicos>().To<VotosServicos>();

            // Infra
            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            kernel.Bind<ILegislaturasRepositorio>().To<LegislaturasRepositorio>();
            kernel.Bind<IMateriasAssuntosRepositorio>().To<MateriasAssuntosRepositorio>();
            kernel.Bind<IMateriasRepositorio>().To<MateriasRepositorio>();
            kernel.Bind<IMateriasSubtiposRepositorio>().To<MateriasSubtiposRepositorio>();
            kernel.Bind<ISenadoresRepositorio>().To<SenadoresRepositorio>();
            kernel.Bind<IVotacoesRepositorio>().To<VotacoesRepositorio>();
            kernel.Bind<IVotosRepositorio>().To<VotosRepositorio>();
        }
    }
}