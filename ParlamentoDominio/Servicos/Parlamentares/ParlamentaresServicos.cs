using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoDominio.Servicos.Parlamentares
{
    public class ParlamentaresServicos : BaseServicos<Parlamentar>, IParlamentaresServicos
    {
        private readonly IParlamentaresRepositorio _repositorio;

        public ParlamentaresServicos(IParlamentaresRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
