using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface IMateriasAssuntosServicosApp : IBaseServicosApp<MateriaAssunto>
    {
        IQueryable<string> ListarGerais();

        IQueryable<string> ListarEspecificos();
    }
}