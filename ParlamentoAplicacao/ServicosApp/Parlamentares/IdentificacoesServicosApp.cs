using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoAplicacao.ServicosApp.Parlamentares
{
    public class IdentificacoesServicosApp : BaseServicosApp<Identificacao>, IIdentificacoesServicosApp
    {
        private readonly IIdentificacoesServicos _servicos;

        public IdentificacoesServicosApp(IIdentificacoesServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}
