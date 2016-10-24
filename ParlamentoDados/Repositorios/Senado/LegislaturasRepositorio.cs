using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using System.Linq;

namespace ParlamentoDados.Repositorios.Senado
{
    public class LegislaturasRepositorio : BaseRepositorio<Legislatura>, ILegislaturasRepositorio
    {
        public Legislatura ObterAtual()
        {
            return Db.Set<Legislatura>().OrderByDescending(x => x.Codigo).FirstOrDefault(x => x.DataEleicao != null);
        }
    }
}