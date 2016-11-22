using System.Linq;
using System.Linq.Expressions;
using ParlamentoDados.Recursos;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using System;
using System.Data.Entity;

namespace ParlamentoDados.Repositorios.Senado
{
    public class MateriasRepositorio : BaseRepositorio<Materia>, IMateriasRepositorio
    {
        public override IQueryable<Materia> Listar(Expression<Func<Materia, bool>> condicoes = null,
            string ordenarPor = null, int deslocamento = -1, int limite = -1, bool noContexto = false)
        {
            // Ordenado Paginado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<Materia>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo)
                    : Db.Set<Materia>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo);
            }

            // Ordenado Paginado
            if (condicoes == null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<Materia>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo)
                    : Db.Set<Materia>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo);
            }

            // Ordenado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<Materia>().Where(condicoes).OrderBy(ordenarPor)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo)
                    : Db.Set<Materia>().AsNoTracking().Where(condicoes).OrderBy(condicoes)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo);
            }

            // Ordenado
            if (condicoes == null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<Materia>().OrderBy(ordenarPor)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo)
                    : Db.Set<Materia>().AsNoTracking().OrderBy(ordenarPor)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo);
            }

            // Condicional
            if (condicoes != null && ordenarPor == null && deslocamento < 0 && limite < 0)
            {
                return noContexto
                    ? Db.Set<Materia>().Where(condicoes)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo)
                    : Db.Set<Materia>().AsNoTracking().Where(condicoes)
                        .Include(x => x.Assunto)
                        .Include(x => x.Subtipo);
            }

            // Tudo
            return noContexto
                ? Db.Set<Materia>()
                    .Include(x => x.Assunto)
                    .Include(x => x.Subtipo)
                : Db.Set<Materia>().AsNoTracking()
                    .Include(x => x.Assunto)
                    .Include(x => x.Subtipo);
        }

        public IQueryable<int> ListarAnos()
        {
            return Db.Set<Materia>().AsNoTracking().Select(x => x.Ano).Distinct();
        }
    }
}