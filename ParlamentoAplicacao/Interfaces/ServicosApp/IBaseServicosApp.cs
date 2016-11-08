using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoAplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade> where TEntidade : class
    {
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

        // Listar
        IEnumerable<TEntidade> Listar(bool emCache = false);

        // Listar Condicional
        IEnumerable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes, bool emCache = false);

        // Listar Paginado
        IEnumerable<TEntidade> Listar(int deslocamento, int limite, bool emCache = false);

        // Listar Paginado Condicional
        IEnumerable<TEntidade> Listar(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, bool emCache = false);

        // Listar Ordenado Asc
        IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Asc Condicional
        IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Asc Paginado
        IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Asc Paginado Condicional
        IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Desc
        IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Desc Condicional
        IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Desc Paginado
        IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        // Listar Ordenado Desc Paginado Condicional
        IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false);

        void AtivarRestricoes();

        void DesativarRestricoes();

        void TruncarTabela();

        void Dispose();
    }
}