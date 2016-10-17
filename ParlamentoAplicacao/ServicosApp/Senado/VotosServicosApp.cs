using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class VotosServicosApp : BaseServicosApp<Voto>, IVotosServicosApp
    {
        private readonly IVotosServicos _servicos;

        public VotosServicosApp(IVotosServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}