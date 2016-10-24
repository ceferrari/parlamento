using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoDominio.Interfaces.Servicos
{
    public interface IBaseServicos<TEntity> where TEntity : class
    {
        void Inserir(TEntity obj);

        void Atualizar(TEntity obj);

        void Mesclar(TEntity obj);

        void Remover(TEntity obj);

        void InserirEmMassa(IEnumerable<TEntity> obj);

        void AtualizarEmMassa(IEnumerable<TEntity> obj);

        void MesclarEmMassa(IEnumerable<TEntity> obj);

        void RemoverEmMassa(IEnumerable<TEntity> obj);

        TEntity ObterPorCodigo(long codigo);

        TEntity ObterPorCodigo(string codigo);

        object Contar(string condicoes);

        IEnumerable<TEntity> Listar(string condicoes, string ordenarPor, bool emCache = false);

        IEnumerable<TEntity> ListarPaginado(int deslocamento, int limite,
            string condicoes, string ordenarPor, bool emCache = false);

        IEnumerable<TEntity> ListarPaginadoAsc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, bool>> condicoes, Expression<Func<TEntity, TKey>> ordenarPor, bool emCache = false);

        IEnumerable<TEntity> ListarPaginadoDesc<TKey>(int deslocamento, int limite,
            Expression<Func<TEntity, bool>> condicoes, Expression<Func<TEntity, TKey>> ordenarPor, bool emCache = false);

        void AtivarRestricoes();

        void DesativarRestricoes();

        void TruncarTabela();

        void Dispose();
    }
}