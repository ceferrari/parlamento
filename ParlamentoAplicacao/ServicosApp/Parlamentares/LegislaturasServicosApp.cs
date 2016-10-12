using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoAplicacao.ServicosApp.Parlamentares
{
    public class LegislaturasServicosApp : BaseServicosApp<Legislatura>, ILegislaturasServicosApp
    {
        private readonly ILegislaturasServicos _servicos;

        public LegislaturasServicosApp(ILegislaturasServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}
