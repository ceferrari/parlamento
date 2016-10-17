using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class LegislaturasServicosApp : BaseServicosApp<Legislatura>, ILegislaturasServicosApp
    {
        private readonly ILegislaturasServicos _servicos;

        public LegislaturasServicosApp(ILegislaturasServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }

        public Legislatura ObterAtual()
        {
            return _servicos.ObterAtual();
        }
    }
}