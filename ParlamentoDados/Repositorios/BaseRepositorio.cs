using ParlamentoDados.Contextos;
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

        public object Contar()
        {
            return new { Total = Db.Set<TEntidade>().AsNoTracking().Count() };
        }

        public object Contar(Expression<Func<TEntidade, bool>> condicoes)
        {
            return new { Total = Db.Set<TEntidade>().AsNoTracking().Count(condicoes) };
        }

        // Listar
        public virtual IEnumerable<TEntidade> Listar(bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().ToList()
                : Db.Set<TEntidade>().AsNoTracking().ToList();
        }

        // Listar Condicional
        public virtual IEnumerable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).ToList();
        }

        // Listar Paginado
        public virtual IEnumerable<TEntidade> Listar(int deslocamento, int limite, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Skip(deslocamento).Take(limite).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Skip(deslocamento).Take(limite).ToList();
        }

        // Listar Paginado Condicional
        public virtual IEnumerable<TEntidade> Listar(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).Skip(deslocamento).Take(limite).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).Skip(deslocamento).Take(limite).ToList();
        }

        // Listar Ordenado Asc
        public virtual IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderBy(ordenarPor).ToList()
                : Db.Set<TEntidade>().AsNoTracking().OrderBy(ordenarPor).ToList();
        }

        // Listar Ordenado Asc Condicional
        public virtual IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderBy(ordenarPor).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderBy(condicoes).ToList();
        }

        // Listar Ordenado Asc Paginado
        public virtual IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                : Db.Set<TEntidade>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList();
        }

        // Listar Ordenado Asc Paginado Condicional
        public virtual IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite).ToList();
        }

        // Listar Ordenado Desc
        public virtual IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderByDescending(ordenarPor).ToList()
                : Db.Set<TEntidade>().AsNoTracking().OrderByDescending(ordenarPor).ToList();
        }

        // Listar Ordenado Desc Condicional
        public virtual IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderByDescending(ordenarPor).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderByDescending(condicoes).ToList();
        }

        // Listar Ordenado Desc Paginado
        public virtual IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                : Db.Set<TEntidade>().AsNoTracking().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList();
        }

        // Listar Ordenado Desc Paginado Condicional
        public virtual IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList()
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite).ToList();
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
            //Db.Set<TEntidade>().SqlQuery("TRUNCATE TABLE NomeTabela");
            Db.Set<TEntidade>().RemoveRange(Db.Set<TEntidade>());
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}