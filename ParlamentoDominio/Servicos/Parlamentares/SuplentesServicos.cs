using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoDominio.Servicos.Parlamentares
{
    public class SuplentesServicos : BaseServicos<Suplente>, ISuplentesServicos
    {
        private readonly ISuplentesRepositorio _repositorio;

        public SuplentesServicos(ISuplentesRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
