using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;

namespace ParlamentoDados.Repositorios.Senado
{
    public class SenadoresRepositorio : BaseRepositorio<Senador>, ISenadoresRepositorio
    {
        public override IEnumerable<Senador> Listar(string condicoes, string ordenarPor, bool emCache = false)
        {
            return emCache
                ? (condicoes == null
                    ? Db.Set<Senador>()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .OrderBy(ordenarPor)
                        .ToList()
                    : Db.Set<Senador>().AsNoTracking()
                        .Where(condicoes)
                        .OrderBy(ordenarPor)
                        .ToList())
                : (condicoes == null
                    ? Db.Set<Senador>().AsNoTracking()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .OrderBy(ordenarPor)
                        .ToList()
                    : Db.Set<Senador>()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .Where(condicoes)
                        .OrderBy(ordenarPor)
                        .ToList());
        }

        public override IEnumerable<Senador> ListarPaginado(int deslocamento, int limite,
            string condicoes, string ordenarPor, bool emCache = false)
        {
            return emCache
                ? (condicoes == null
                    ? Db.Set<Senador>()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .OrderBy(ordenarPor)
                        .Skip(deslocamento)
                        .Take(limite)
                        .ToList()
                    : Db.Set<Senador>()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .Where(condicoes)
                        .OrderBy(ordenarPor)
                        .Skip(deslocamento)
                        .Take(limite)
                        .ToList())
                : (condicoes == null
                    ? Db.Set<Senador>().AsNoTracking()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .OrderBy(ordenarPor)
                        .Skip(deslocamento)
                        .Take(limite)
                        .ToList()
                    : Db.Set<Senador>().AsNoTracking()
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                        .Include(x => x.Votos)
                        .Where(condicoes)
                        .OrderBy(ordenarPor)
                        .Skip(deslocamento)
                        .Take(limite)
                        .ToList());
        }
    }
}