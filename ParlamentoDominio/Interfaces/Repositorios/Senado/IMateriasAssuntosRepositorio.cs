using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface IMateriasAssuntosRepositorio : IBaseRepositorio<MateriaAssunto>
    {
        IQueryable<string> ListarGerais();

        IQueryable<string> ListarEspecificos();
    }
}