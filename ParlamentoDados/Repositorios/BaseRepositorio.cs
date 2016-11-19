using ParlamentoDados.Contextos;
using ParlamentoDados.Recursos;
using ParlamentoDominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ParlamentoDados.Repositorios
{
    public abstract class BaseRepositorio<TEntidade> : IDisposable, IBaseRepositorio<TEntidade> where TEntidade : class
    {
        protected readonly BaseContexto Db = new BaseContexto();

        public void Dispose()
        {
            Db.Dispose();
        }

        public void AtivarRestricoes()
        {
            Db.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable \"ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL\"");
            Db.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable \"ALTER TABLE ? ENABLE TRIGGER ALL\"");
        }

        public void DesativarRestricoes()
        {
            Db.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable \"ALTER TABLE ? NOCHECK CONSTRAINT ALL\"");
            Db.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable \"ALTER TABLE ? DISABLE TRIGGER ALL\"");
        }

        public void TruncarTabela(string tabela)
        {
            Db.Database.ExecuteSqlCommand("EXEC TruncarTabela @p0", tabela);

            //Db.Database.ExecuteSqlCommand("TRUNCATE TABLE @p0", tabela);
            //Db.Set<TEntidade>().RemoveRange(Db.Set<TEntidade>());
            //Db.SaveChanges();
        }

        public void Inserir(TEntidade obj)
        {
            Db.Set<TEntidade>().Add(obj);
            Db.SaveChanges();
        }

        public void Atualizar(TEntidade obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Mesclar(TEntidade obj)
        {
            Db.Set<TEntidade>().AddOrUpdate(obj);
            Db.SaveChanges();
        }

        public void Remover(TEntidade obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public void InserirEmMassa(IEnumerable<TEntidade> obj)
        {
            Db.BulkInsert(obj);
            Db.BulkSaveChanges();
        }

        public void AtualizarEmMassa(IEnumerable<TEntidade> obj)
        {
            Db.BulkUpdate(obj);
            Db.BulkSaveChanges();
        }

        public void MesclarEmMassa(IEnumerable<TEntidade> obj)
        {
            Db.BulkMerge(obj);
            Db.BulkSaveChanges();

            AtivarRestricoes();
        }

        public void RemoverEmMassa(IEnumerable<TEntidade> obj)
        {
            Db.BulkDelete(obj);
            Db.BulkSaveChanges();
        }

        public TEntidade ObterPorChave(object chave)
        {
            return ObterPorChave(new[] { chave });
        }

        public TEntidade ObterPorChave(object[] chave)
        {
            return Db.Set<TEntidade>().Find(chave);
        }

        public object Contar(Expression<Func<TEntidade, bool>> condicoes = null)
        {
            return condicoes == null
                ? new { Total = Db.Set<TEntidade>().AsNoTracking().Count() }
                : new { Total = Db.Set<TEntidade>().AsNoTracking().Count(condicoes) };
        }

        public virtual IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes = null,
            string ordenarPor = null, int deslocamento = -1, int limite = -1,  bool noContexto = false)
        {
            // Ordenado Paginado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<TEntidade>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                    : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite);
            }

            // Ordenado Paginado
            if (condicoes == null && ordenarPor != null && deslocamento > -1 && limite > 0)
            {
                return noContexto
                    ? Db.Set<TEntidade>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                    : Db.Set<TEntidade>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite);
            }

            // Ordenado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<TEntidade>().Where(condicoes).OrderBy(ordenarPor)
                    : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderBy(condicoes);
            }

            // Ordenado
            if (condicoes == null && ordenarPor != null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<TEntidade>().OrderBy(ordenarPor)
                    : Db.Set<TEntidade>().AsNoTracking().OrderBy(ordenarPor);
            }

            // Condicional
            if (condicoes != null && ordenarPor == null && deslocamento < 0 && limite < 1)
            {
                return noContexto
                    ? Db.Set<TEntidade>().Where(condicoes)
                    : Db.Set<TEntidade>().AsNoTracking().Where(condicoes);
            }

            // Tudo
            return noContexto
                ? Db.Set<TEntidade>()
                : Db.Set<TEntidade>().AsNoTracking();
        }
    }
}