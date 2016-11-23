using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface IMateriasServicos : IBaseServicos<Materia>
    {
        IQueryable<int> ListarAnos();
    }
}