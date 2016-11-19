using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using System.Linq;

namespace ParlamentoDados.Repositorios.Senado
{
    public class MateriasAssuntosRepositorio : BaseRepositorio<MateriaAssunto>, IMateriasAssuntosRepositorio
    {
        public IQueryable<string> ListarGerais()
        {
            return Db.Set<MateriaAssunto>().AsNoTracking().Select(x => x.AssuntoGeral).Distinct();
        }

        public IQueryable<string> ListarEspecificos()
        {
            return Db.Set<MateriaAssunto>().AsNoTracking().Select(x => x.AssuntoEspecifico).Distinct();
        }
    }
}