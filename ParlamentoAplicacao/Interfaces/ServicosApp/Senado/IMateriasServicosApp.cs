using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface IMateriasServicosApp : IBaseServicosApp<Materia>
    {
        IQueryable<int> ListarAnos();
    }
}