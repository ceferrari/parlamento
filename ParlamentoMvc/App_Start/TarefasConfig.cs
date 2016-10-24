using Hangfire;
using Ninject;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System;

namespace ParlamentoMvc
{
    public class TarefasConfig
    {
        public static void Hangfire()
        {
            RecurringJob.AddOrUpdate<IAtualizarLegislaturasTarefa>("AtualizarLegislaturas", j => j.Executar(), Cron.Yearly, TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<IAtualizarMateriasTarefa>("AtualizarMaterias", j => j.Executar(), Cron.Yearly, TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<IAtualizarSenadoresTarefa>("AtualizarSenadores", j => j.Executar(), Cron.Yearly, TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<IAtualizarVotosTarefa>("AtualizarVotos", j => j.Executar(), Cron.Yearly, TimeZoneInfo.Local);
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