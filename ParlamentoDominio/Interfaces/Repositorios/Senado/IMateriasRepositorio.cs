using System.Linq;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface IMateriasRepositorio : IBaseRepositorio<Materia>
    {
        IQueryable<int> ListarAnos();
    }
}