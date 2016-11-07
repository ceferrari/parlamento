using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoRecursos.Recursos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System;

namespace ParlamentoApi
{
    public class TarefasConfig
    {
        public static void Hangfire()
        {
            RecurringJob.AddOrUpdate<IAtualizarLegislaturasTarefa>("AtualizarLegislaturas", j => j.Executar(), "0 0 * * *", TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<IAtualizarMateriasTarefa>("AtualizarMaterias", j => j.Executar(), "0 2 * * *", TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<IAtualizarSenadoresTarefa>("AtualizarSenadores", j => j.Executar(), "0 1 * * *", TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<IAtualizarVotosTarefa>("AtualizarVotos", j => j.Executar(), "0 4 * * *", TimeZoneInfo.Local);
        }

        public static void AutoMapper()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BasePerfilMapeamento>();
            });
        }

        public static void Ninject(IKernel kernel)
        {
            ParlamentoTarefas.Recursos.NinjectBootstrapper.RegisterServices(kernel);
        }
    }
}