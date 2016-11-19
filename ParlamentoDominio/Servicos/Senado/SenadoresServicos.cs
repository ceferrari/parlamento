using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;
using System.Linq;

namespace ParlamentoDominio.Servicos.Senado
{
    public class SenadoresServicos : BaseServicos<Senador>, ISenadoresServicos
    {
        private readonly ISenadoresRepositorio _repositorio;

        public SenadoresServicos(ISenadoresRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryable<string> ListarPartidos()
        {
            return _repositorio.ListarPartidos();
        }

        public IQueryable<string> ListarEstados()
        {
            return _repositorio.ListarEstados();
        }

        public IQueryable<string> ListarSexos()
        {
            return _repositorio.ListarSexos();
        }
    }
}