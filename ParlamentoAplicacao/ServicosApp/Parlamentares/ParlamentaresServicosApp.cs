using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoAplicacao.ServicosApp.Parlamentares
{
    public class ParlamentaresServicosApp : BaseServicosApp<Parlamentar>, IParlamentaresServicosApp
    {
        private readonly IParlamentaresServicos _servicos;

        public ParlamentaresServicosApp(IParlamentaresServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}
