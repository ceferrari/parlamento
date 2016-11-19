using ParlamentoDados.Recursos;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ParlamentoDados.Repositorios.Senado
{
    public class VotosRepositorio : BaseRepositorio<Voto>, IVotosRepositorio
    {
        public override IQueryable<Voto> Listar(Expression<Func<Voto, bool>> condicoes = null,
            string ordenarPor = null, int deslocamento = -1, int limite = -1, bool noContexto = false)
        {
            // Ordenado Paginado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<Voto>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo)
                    : Db.Set<Voto>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo);
            }

            // Ordenado Paginado
            if (condicoes == null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<Voto>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo)
                    : Db.Set<Voto>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo);
            }

            // Ordenado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<Voto>().Where(condicoes).OrderBy(ordenarPor)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo)
                    : Db.Set<Voto>().AsNoTracking().Where(condicoes).OrderBy(condicoes)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo);
            }

            // Ordenado
            if (condicoes == null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<Voto>().OrderBy(ordenarPor)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo)
                    : Db.Set<Voto>().AsNoTracking().OrderBy(ordenarPor)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo);
            }

            // Condicional
            if (condicoes != null && ordenarPor == null && deslocamento < 0 && limite < 0)
            {
                return noContexto
                    ? Db.Set<Voto>().Where(condicoes)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo)
                    : Db.Set<Voto>().AsNoTracking().Where(condicoes)
                        .Include(x => x.Materia.Assunto)
                        .Include(x => x.Materia.Subtipo);
            }

            // Tudo
            return noContexto
                ? Db.Set<Voto>()
                    .Include(x => x.Materia.Assunto)
                    .Include(x => x.Materia.Subtipo)
                : Db.Set<Voto>().AsNoTracking()
                    .Include(x => x.Materia.Assunto)
                    .Include(x => x.Materia.Subtipo);
        }
    }
}