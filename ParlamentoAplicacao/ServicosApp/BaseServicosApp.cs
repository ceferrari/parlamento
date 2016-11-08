using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoAplicacao.ServicosApp
{
    public abstract class BaseServicosApp<TEntidade> : IDisposable, IBaseServicosApp<TEntidade> where TEntidade : class
    {
        private readonly IBaseServicos<TEntidade> _servicos;

        protected BaseServicosApp(IBaseServicos<TEntidade> servicos)
        {
            _servicos = servicos;
        }

        public void Inserir(TEntidade obj)
        {
            _servicos.Inserir(obj);
        }

        public void Atualizar(TEntidade obj)
        {
            _servicos.Atualizar(obj);
        }

        public void Mesclar(TEntidade obj)
        {
            _servicos.Mesclar(obj);
        }

        public void Remover(TEntidade obj)
        {
            _servicos.Remover(obj);
        }

        public void InserirEmMassa(IEnumerable<TEntidade> obj)
        {
            _servicos.InserirEmMassa(obj);
        }

        public void AtualizarEmMassa(IEnumerable<TEntidade> obj)
        {
            _servicos.AtualizarEmMassa(obj);
        }

        public void MesclarEmMassa(IEnumerable<TEntidade> obj)
        {
            _servicos.MesclarEmMassa(obj);
        }

        public void RemoverEmMassa(IEnumerable<TEntidade> obj)
        {
            _servicos.RemoverEmMassa(obj);
        }

        public TEntidade ObterPorChave(object chave)
        {
            return _servicos.ObterPorChave(chave);
        }

        public TEntidade ObterPorChave(object[] chave)
        {
            return _servicos.ObterPorChave(chave);
        }

        public object Contar()
        {
            return _servicos.Contar();
        }

        public object Contar(Expression<Func<TEntidade, bool>> condicoes)
        {
            return _servicos.Contar(condicoes);
        }

        public IEnumerable<TEntidade> Listar(bool emCache = false)
        {
            return _servicos.Listar(emCache);
        }

        public IEnumerable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes, bool emCache = false)
        {
            return _servicos.Listar(condicoes, emCache);
        }

        public IEnumerable<TEntidade> Listar(int deslocamento, int limite, bool emCache = false)
        {
            return _servicos.Listar(deslocamento, limite, emCache);
        }

        public IEnumerable<TEntidade> Listar(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, bool emCache = false)
        {
            return _servicos.Listar(deslocamento, limite, condicoes, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarAsc(ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarAsc(condicoes, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarAsc(deslocamento, limite, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarAsc(deslocamento, limite, condicoes, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarDesc(ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarDesc(condicoes, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarDesc(deslocamento, limite, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _servicos.ListarDesc(deslocamento, limite, condicoes, ordenarPor, emCache);
        }

        public void AtivarRestricoes()
        {
            _servicos.AtivarRestricoes();
        }

        public void DesativarRestricoes()
        {
            _servicos.DesativarRestricoes();
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