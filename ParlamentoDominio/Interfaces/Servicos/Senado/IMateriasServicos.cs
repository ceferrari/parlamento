using System.Linq;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface IMateriasServicos : IBaseServicos<Materia>
    {
        IQueryable<int> ListarAnos();
    }
}