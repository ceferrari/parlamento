using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface ISenadoresRepositorio : IBaseRepositorio<Senador>
    {
        IQueryable<string> ListarPartidos();
        IQueryable<string> ListarEstados();
        IQueryable<string> ListarSexos();
    }
}