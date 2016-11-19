using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface IMateriasAssuntosServicos : IBaseServicos<MateriaAssunto>
    {
        IQueryable<string> ListarGerais();

        IQueryable<string> ListarEspecificos();
    }
}