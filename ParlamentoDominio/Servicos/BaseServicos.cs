using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoDominio.Servicos
{
    public class BaseServicos<TEntity> : IDisposable, IBaseServicos<TEntity> where TEntity : class
    {
        private readonly IBaseRepositorio<TEntity> _repositorio;

        public BaseServicos(IBaseRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Inserir(TEntity obj)
        {
            _repositorio.Inserir(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repositorio.Atualizar(obj);
        }

        public void Mesclar(TEntity obj)
        {
            _repositorio.Mesclar(obj);
        }

        public void Remover(TEntity obj)
        {
            _repositorio.Remover(obj);
        }

        public void InserirEmMassa(IEnumerable<TEntity> obj)
        {
            _repositorio.InserirEmMassa(obj);
        }

        public void AtualizarEmMassa(IEnumerable<TEntity> obj)
        {
            _repositorio.AtualizarEmMassa(obj);
        }

        public void MesclarEmMassa(IEnumerable<TEntity> obj)
        {
            _repositorio.MesclarEmMassa(obj);
        }

        public void RemoverEmMassa(IEnumerable<TEntity> obj)
        {
            _repositorio.RemoverEmMassa(obj);
        }

        public TEntity ObterPorCodigo(long codigo)
        {
            return _repositorio.ObterPorCodigo(codigo);
        }

        public TEntity ObterPorCodigo(string codigo)
        {
            return _repositorio.ObterPorCodigo(codigo);
        }

        public IEnumerable<TEntity> Listar(bool semCache = false)
        {
            return _repositorio.Listar();
        }

        public IEnumerable<TEntity> ListarPaginado(int deslocamento, int limite,
            string ordenarPor, string condicoes, bool semCache = false)
        {
            return _repositorio.ListarPaginado(deslocamento, limite, ordenarPor, condicoes, semCache);
        }

        public IEnumerable<TEntity> ListarPaginadoDesc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false)
        {
            return _repositorio.ListarPaginadoDesc(deslocamento, limite, ordenarPor, condicoes, semCache);
        }

        public IEnumerable<TEntity> ListarPaginadoAsc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false)
        {
            return _repositorio.ListarPaginadoAsc(deslocamento, limite, ordenarPor, condicoes, semCache);
        }

        public void TruncarTabela()
        {
            _repositorio.TruncarTabela();
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}