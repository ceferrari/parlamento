using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoDominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<TEntidade> where TEntidade : class
    {
        void Dispose();

        void AtivarRestricoes();

        void DesativarRestricoes();

        void TruncarTabela(string tabela);
        
        void Inserir(TEntidade obj);

        void Atualizar(TEntidade obj);

        void Mesclar(TEntidade obj);

        void Remover(TEntidade obj);

        void InserirEmMassa(IEnumerable<TEntidade> obj);

        void AtualizarEmMassa(IEnumerable<TEntidade> obj);

        void MesclarEmMassa(IEnumerable<TEntidade> obj);

        void RemoverEmMassa(IEnumerable<TEntidade> obj);

        TEntidade ObterPorChave(object chave);

        TEntidade ObterPorChave(object[] chave);

        object Contar(Expression<Func<TEntidade, bool>> condicoes = null);

        IEnumerable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes = null,
            string ordenarPor = null, int deslocamento = -1, int limite = -1, bool noContexto = false);
    }
}