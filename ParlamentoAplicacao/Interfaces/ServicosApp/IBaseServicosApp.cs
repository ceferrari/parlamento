using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoAplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntity> where TEntity : class
    {
        void Inserir(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        void Mesclar(TEntity obj);

        void InserirEmMassa(IEnumerable<TEntity> obj);

        void AtualizarEmMassa(IEnumerable<TEntity> obj);

        void RemoverEmMassa(IEnumerable<TEntity> obj);

        void MesclarEmMassa(IEnumerable<TEntity> obj);

        TEntity ObterPorCodigo(long codigo);

        TEntity ObterPorCodigo(string codigo);

        IEnumerable<TEntity> Listar(bool semCache = false);

        IEnumerable<TEntity> ListarPaginado(int deslocamento, int limite,
            string ordenarPor, string condicoes, bool semCache = false);

        IEnumerable<TEntity> ListarPaginadoAsc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false);

        IEnumerable<TEntity> ListarPaginadoDesc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, TKey>> ordenarPor, Expression<Func<TEntity, bool>> condicoes, bool semCache = false);

        void TruncarTabela();

        void Dispose();
    }
}