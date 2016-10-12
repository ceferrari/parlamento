using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoAplicacao.ServicosApp
{
    public class BaseServicosApp<TEntity> : IDisposable, IBaseServicosApp<TEntity> where TEntity : class
    {
        private readonly IBaseServicos<TEntity> _servicos;

        public BaseServicosApp(IBaseServicos<TEntity> servicos)
        {
            _servicos = servicos;
        }

        public void Inserir(TEntity obj)
        {
            _servicos.Inserir(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _servicos.Atualizar(obj);
        }

        public void Mesclar(TEntity obj)
        {
            _servicos.Mesclar(obj);
        }

        public void Remover(TEntity obj)
        {
            _servicos.Remover(obj);
        }

        public void InserirEmMassa(IEnumerable<TEntity> obj)
        {
            _servicos.InserirEmMassa(obj);
        }

        public void AtualizarEmMassa(IEnumerable<TEntity> obj)
        {
            _servicos.AtualizarEmMassa(obj);
        }

        public void MesclarEmMassa(IEnumerable<TEntity> obj)
        {
            _servicos.MesclarEmMassa(obj);
        }

        public void RemoverEmMassa(IEnumerable<TEntity> obj)
        {
            _servicos.RemoverEmMassa(obj);
        }

        public TEntity ObterPorCodigo(long codigo)
        {
            return _servicos.ObterPorCodigo(codigo);
        }

        public TEntity ObterPorCodigo(string codigo)
        {
            return _servicos.ObterPorCodigo(codigo);
        }

        public IEnumerable<TEntity> Listar(bool semCache = false)
        {
            return _servicos.Listar();
        }

        public IEnumerable<TEntity> ListarPaginado(int deslocamento, int limite,
            string ordenarPor, string condicoes, bool semCache = false)
        {
            return _servicos.ListarPaginado(deslocamento, limite, ordenarPor, condicoes, semCache);
        }

        public IEnumerable<TEntity> ListarPaginadoAsc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false)
        {
            return _servicos.ListarPaginadoAsc(deslocamento, limite, ordenarPor, condicoes, semCache);
        }

        public IEnumerable<TEntity> ListarPaginadoDesc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false)
        {
            return _servicos.ListarPaginadoDesc(deslocamento, limite, ordenarPor, condicoes, semCache);
        }

        public void TruncarTabela()
        {
            _servicos.TruncarTabela();
        }

        public void Dispose()
        {
            _servicos.Dispose();
        }
    }
}