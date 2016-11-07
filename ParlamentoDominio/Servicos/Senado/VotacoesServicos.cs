using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoDominio.Servicos.Senado
{
    public class VotacoesServicos : BaseServicos<Votacao>, IVotacoesServicos
    {
        private readonly IVotacoesRepositorio _repositorio;

        public VotacoesServicos(IVotacoesRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}