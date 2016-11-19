using System.Linq;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface IMateriasAssuntosServicos : IBaseServicos<MateriaAssunto>
    {
        IQueryable<string> ListarGerais();

        IQueryable<string> ListarEspecificos();
    }
}