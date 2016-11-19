using System.Linq;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface IMateriasAssuntosServicosApp : IBaseServicosApp<MateriaAssunto>
    {
        IQueryable<string> ListarGerais();

        IQueryable<string> ListarEspecificos();
    }
}