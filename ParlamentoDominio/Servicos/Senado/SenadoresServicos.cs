using System.Collections.Generic;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

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

        public IEnumerable<string> ListarPartidos()
        {
            return _repositorio.ListarPartidos();
        }

        public IEnumerable<string> ListarEstados()
        {
            return _repositorio.ListarEstados();
        }

        public IEnumerable<string> ListarSexos()
        {
            return _repositorio.ListarSexos();
        }
    }
}