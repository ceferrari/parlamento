using Hangfire;
using Ninject;
using ParlamentoTarefas.Interfaces.Tarefas.Parlamentares;

namespace ParlamentoMvc
{
    public class TarefasConfig
    {
        public static void Hangfire()
        {
            RecurringJob.AddOrUpdate<IAtualizarSenadoresTarefa>("AtualizarSenadores", j => j.Executar(), Cron.Yearly);
        }

        public static void AutoMapper()
        {
            ParlamentoTarefas.AutoMapperConfig.RegisterMappings();
        }

        public static void Ninject(IKernel kernel)
        {
            ParlamentoTarefas.NinjectBootstrapper.RegisterServices(kernel);
        }
    }
}