using Hangfire;
using System.Web.Hosting;

namespace ParlamentoApi
{
    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

        private readonly object _lockObject = new object();
        private bool _started;

        private BackgroundJobServer _backgroundJobServer;

        private HangfireBootstrapper()
        {
        }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;

                HostingEnvironment.RegisterObject(this);

                GlobalConfiguration.Configuration
                    .UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel)
                    .UseSqlServerStorage("ApiConexao");

                _backgroundJobServer = new BackgroundJobServer();
            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                _backgroundJobServer?.Dispose();

                HostingEnvironment.UnregisterObject(this);
            }
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }
    }
}