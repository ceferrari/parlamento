using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using ParlamentoDados.Contextos;
using ParlamentoDominio.Interfaces.Repositorios;

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

        public IEnumerable<TEntity> Listar(bool semCache = false)
        {
            return semCache
                ? Db.Set<TEntity>().AsNoTracking().ToList()
                : Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> ListarPaginado(int deslocamento, int limite,
            string ordenarPor, string condicoes, bool semCache = false)
        {
            return semCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList());
        }

        public IEnumerable<TEntity> ListarPaginadoAsc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false)
        {
            return semCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList());
        }

        public IEnumerable<TEntity> ListarPaginadoDesc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false)
        {
            return semCache
                ? (condicoes == null
                    ? Db.Set<TEntity>().AsNoTracking().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().AsNoTracking().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList())
                : (condicoes == null
                    ? Db.Set<TEntity>().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                    : Db.Set<TEntity>().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList());
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