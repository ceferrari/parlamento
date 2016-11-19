using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartup(typeof(ParlamentoApi.Startup))]

namespace ParlamentoApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            TarefasConfig.Hangfire();

            app.UseHangfireDashboard("/crons", new DashboardOptions
            {
                Authorization = Enumerable.Empty<IDashboardAuthorizationFilter>()
            });

            //app.UseHangfireServer();
        }
    }
}