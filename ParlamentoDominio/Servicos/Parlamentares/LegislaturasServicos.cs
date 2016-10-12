using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoDominio.Servicos.Parlamentares
{
    public class LegislaturasServicos : BaseServicos<Legislatura>, ILegislaturasServicos
    {
        private readonly ILegislaturasRepositorio _repositorio;

        public LegislaturasServicos(ILegislaturasRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
