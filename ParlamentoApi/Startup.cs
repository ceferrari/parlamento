using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ParlamentoApi.Startup))]

namespace ParlamentoApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel)
                .UseSqlServerStorage(@"Data Source=.\SQLEXPRESS;Initial Catalog=ParlamentoTarefas;Integrated Security=True");

            TarefasConfig.Hangfire();

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}