using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface IMateriasRepositorio : IBaseRepositorio<Materia>
    {
        IQueryable<int> ListarAnos();
    }
}