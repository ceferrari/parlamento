using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoAplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade> where TEntidade : class
    {
        void Dispose();

        void AtivarRestricoes();

        void DesativarRestricoes();

        void TruncarTabela();

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

        object Contar();

        object Contar(Expression<Func<TEntidade, bool>> condicoes);

        IEnumerable<TEntidade> Listar<TChave>(
            Expression<Func<TEntidade, bool>> condicoes = null,
            Expression<Func<TEntidade, TChave>> ordenarPor = null, string ordem = "asc",
            int deslocamento = -1, int limite = -1, bool emCache = false);
    }
}