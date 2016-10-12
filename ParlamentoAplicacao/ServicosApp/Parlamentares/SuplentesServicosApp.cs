using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoAplicacao.ServicosApp.Parlamentares
{
    public class SuplentesServicosApp : BaseServicosApp<Suplente>, ISuplentesServicosApp
    {
        private readonly ISuplentesServicos _servicos;

        public SuplentesServicosApp(ISuplentesServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}
