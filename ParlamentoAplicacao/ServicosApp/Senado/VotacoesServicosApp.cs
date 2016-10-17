using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class VotacoesServicosApp : BaseServicosApp<Votacao>, IVotacoesServicosApp
    {
        private readonly IVotacoesServicos _servicos;

        public VotacoesServicosApp(IVotacoesServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}