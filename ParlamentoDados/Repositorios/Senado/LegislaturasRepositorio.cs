using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;

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