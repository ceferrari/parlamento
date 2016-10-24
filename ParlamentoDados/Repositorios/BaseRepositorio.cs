using ParlamentoDados.Contextos;
using ParlamentoDominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace ParlamentoDados.Repositorios
{
    public class BaseRepositorio<TEntity> : IDisposable, IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly BaseContexto Db = new BaseContexto();

        public void Inserir(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Mesclar(TEntity obj)
        {
            Db.Set<TEntity>().AddOrUpdate(obj);
            Db.SaveChanges();
        }

        public void Remover(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void InserirEmMassa(IEnumerable<TEntity> obj)
        {
            Db.BulkInsert(obj);
            Db.BulkSaveChanges();
        }

        public void AtualizarEmMassa(IEnumerable<TEntity> obj)
        {
            Db.BulkUpdate(obj);
            Db.BulkSaveChanges();
        }

        public void MesclarEmMassa(IEnumerable<TEntity> obj)
        {
            Db.BulkMerge(obj);
            Db.BulkSaveChanges();
        }

        public void RemoverEmMassa(IEnumerable<TEntity> obj)
        {
            Db.BulkDelete(obj);
            Db.BulkSaveChanges();
        }

        public TEntity ObterPorCodigo(long codigo)
        {
            return Db.Set<TEntity>().Find(codigo);
        }

        public TEntity ObterPorCodigo(string codigo)
        {
            return Db.Set<TEntity>().Find(codigo);
        }

        public object Contar(string condicoes)
        {
            return condicoes == null
                ? new { Total = Db.Set<TEntity>().AsNoTracking().Count() }
                : new { Total = Db.Set<TEntity>().AsNoTracking().Where(condicoes).Count() };
        }

        public virtual IEnumerable<TEntity> Listar(string condicoes, string ordenarPor, bool emCache = false)
        {
            return emCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().OrderBy(ordenarPor).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderBy(ordenarPor).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderBy(ordenarPor).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).ToList());
        }

        public virtual IEnumerable<TEntity> ListarPaginado(int deslocamento, int limite,
            string condicoes, string ordenarPor, bool emCache = false)
        {
            return emCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList());
        }

        public IEnumerable<TEntity> ListarPaginadoAsc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, bool>> condicoes, Expression<Func<TEntity, TKey>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList());
        }

        public IEnumerable<TEntity> ListarPaginadoDesc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, bool>> condicoes, Expression<Func<TEntity, TKey>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList());
        }

        public void AtivarRestricoes()
        {
            Db.Database.SqlQuery<string>("EXEC sp_msforeachtable \"ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL\";");
        }

        public void DesativarRestricoes()
        {
            Db.Database.SqlQuery<string>("EXEC sp_msforeachtable \"ALTER TABLE ? NOCHECK CONSTRAINT ALL\";");
        }

        public void TruncarTabela()
        {
            //Db.Set<TEntity>().SqlQuery("TRUNCATE TABLE NomeTabela");
            Db.Set<TEntity>().RemoveRange(Db.Set<TEntity>());
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}