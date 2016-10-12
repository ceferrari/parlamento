using ParlamentoDominio.Entidades;
using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Servicos;

namespace ParlamentoDominio.Servicos
{
    public class ExemplosServicos : BaseServicos<Exemplo>, IExemplosServicos
    {
        private readonly IExemplosRepositorio _repositorio;

        public ExemplosServicos(IExemplosRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}