using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface ISenadoresRepositorio : IBaseRepositorio<Senador>
    {
        IEnumerable<string> ListarPartidos();
        IEnumerable<string> ListarEstados();
        IEnumerable<string> ListarSexos();
    }
}