using ParlamentoDados.Recursos;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ParlamentoDados.Repositorios.Senado
{
    public class SenadoresRepositorio : BaseRepositorio<Senador>, ISenadoresRepositorio
    {
        public override IQueryable<Senador> Listar(Expression<Func<Senador, bool>> condicoes = null,
            string ordenarPor = null, int deslocamento = -1, int limite = -1, bool noContexto = false)
        {
            // Ordenado Paginado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<Senador>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                    : Db.Set<Senador>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura);
            }

            // Ordenado Paginado
            if (condicoes == null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<Senador>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                    : Db.Set<Senador>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura);
            }

            // Ordenado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<Senador>().Where(condicoes).OrderBy(ordenarPor)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                    : Db.Set<Senador>().AsNoTracking().Where(condicoes).OrderBy(condicoes)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura);
            }

            // Ordenado
            if (condicoes == null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<Senador>().OrderBy(ordenarPor)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                    : Db.Set<Senador>().AsNoTracking().OrderBy(ordenarPor)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura);
            }

            // Condicional
            if (condicoes != null && ordenarPor == null && deslocamento < 0 && limite < 0)
            {
                return noContexto
                    ? Db.Set<Senador>().Where(condicoes)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura)
                    : Db.Set<Senador>().AsNoTracking().Where(condicoes)
                        .Include(x => x.PrimeiraLegislatura)
                        .Include(x => x.SegundaLegislatura);
            }

            // Tudo
            return noContexto
                ? Db.Set<Senador>()
                    .Include(x => x.PrimeiraLegislatura)
                    .Include(x => x.SegundaLegislatura)
                : Db.Set<Senador>().AsNoTracking()
                    .Include(x => x.PrimeiraLegislatura)
                    .Include(x => x.SegundaLegislatura);
        }

        public IQueryable<string> ListarPartidos()
        {
            return Db.Set<Senador>().AsNoTracking().Select(x => x.SiglaPartido).Distinct();
        }

        public IQueryable<string> ListarEstados()
        {
            return Db.Set<Senador>().AsNoTracking().Select(x => x.UfMandato).Distinct();
        }

        public IQueryable<string> ListarSexos()
        {
            return Db.Set<Senador>().AsNoTracking().Select(x => x.Sexo).Distinct();
        }
    }
}