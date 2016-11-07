using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoDominio.Servicos.Senado
{
    public class LegislaturasServicos : BaseServicos<Legislatura>, ILegislaturasServicos
    {
        private readonly ILegislaturasRepositorio _repositorio;

        public LegislaturasServicos(ILegislaturasRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }

        public Legislatura ObterAtual()
        {
            return _repositorio.ObterAtual();
        }
    }
}