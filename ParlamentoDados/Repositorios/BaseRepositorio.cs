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

        public virtual IEnumerable<TEntidade> Listar<TChave>(
            Expression<Func<TEntidade, bool>> condicoes = null,
            Expression<Func<TEntidade, TChave>> ordenarPor = null, string ordem = "asc", 
            int deslocamento = -1, int limite = -1,  bool emCache = false)
        {
            // Ordenado Paginado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento > -1 && limite > -1)
            {
                return string.Equals(ordem, "asc", StringComparison.OrdinalIgnoreCase)
                    ? ListarAsc(condicoes, ordenarPor, deslocamento, limite, emCache)
                    : ListarDesc(condicoes, ordenarPor, deslocamento, limite, emCache);
            }

            // Ordenado Paginado
            if (condicoes == null && ordenarPor != null && deslocamento > -1 && limite > -1)
            {
                return string.Equals(ordem, "asc", StringComparison.OrdinalIgnoreCase)
                    ? ListarAsc(ordenarPor, deslocamento, limite, emCache)
                    : ListarDesc(ordenarPor, deslocamento, limite, emCache);
            }

            // Ordenado Condicional
            if (condicoes != null && ordenarPor != null && deslocamento < 0 && limite < 0)
            {
                return string.Equals(ordem, "asc", StringComparison.OrdinalIgnoreCase)
                    ? ListarAsc(condicoes, ordenarPor, emCache)
                    : ListarDesc(condicoes, ordenarPor, emCache);
            }

            // Ordenado
            if (condicoes == null && ordenarPor != null && deslocamento < 0 && limite < 0)
            {
                return string.Equals(ordem, "asc", StringComparison.OrdinalIgnoreCase)
                    ? ListarAsc(ordenarPor, emCache)
                    : ListarDesc(ordenarPor, emCache);
            }

            // Condicional
            if (condicoes != null && ordenarPor == null && deslocamento < 0 && limite < 0)
            {
                return Listar(condicoes, emCache);
            }

            // Tudo
            return Listar(emCache);
        }

        // Métodos privados auxiliares do Listar

        // Tudo
        private IEnumerable<TEntidade> Listar(bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>()
                : Db.Set<TEntidade>().AsNoTracking();
        }

        // Condicional
        private IEnumerable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes)
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes);
        }

        // Ordenado (Asc)
        private IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderBy(ordenarPor)
                : Db.Set<TEntidade>().AsNoTracking().OrderBy(ordenarPor);
        }

        // Ordenado (Desc)
        private IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderByDescending(ordenarPor)
                : Db.Set<TEntidade>().AsNoTracking().OrderByDescending(ordenarPor);
        }

        // Ordenado Condicional (Asc)
        private IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderBy(ordenarPor)
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderBy(condicoes);
        }

        // Ordenado Condicional (Desc)
        private IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderByDescending(ordenarPor)
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderByDescending(condicoes);
        }

        // Ordenado Paginado (Asc)
        private IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, int deslocamento, int limite, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                : Db.Set<TEntidade>().AsNoTracking().OrderBy(ordenarPor).Skip(deslocamento).Take(limite);
        }

        // Ordenado Paginado (Desc)
        private IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, int deslocamento, int limite, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite)
                : Db.Set<TEntidade>().AsNoTracking().OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite);
        }

        // Ordenado Paginado Condicional (Asc)
        private IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, int deslocamento, int limite, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite)
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderBy(ordenarPor).Skip(deslocamento).Take(limite);
        }
        
        // Ordenado Paginado Condicional (Desc)
        private IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, int deslocamento, int limite, bool emCache)
        {
            return emCache
                ? Db.Set<TEntidade>().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite)
                : Db.Set<TEntidade>().AsNoTracking().Where(condicoes).OrderByDescending(ordenarPor).Skip(deslocamento).Take(limite);
        }
    }
}