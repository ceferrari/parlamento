using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoDominio.Servicos.Parlamentares
{
    public class IdentificacoesServicos : BaseServicos<Identificacao>, IIdentificacoesServicos
    {
        private readonly IIdentificacoesRepositorio _repositorio;

        public IdentificacoesServicos(IIdentificacoesRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
