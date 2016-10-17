using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ParlamentoMvc.Startup))]

namespace ParlamentoMvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel)
                .UseSqlServerStorage("BaseConexao");

            TarefasConfig.Hangfire();

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}