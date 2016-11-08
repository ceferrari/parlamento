using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParlamentoDominio.Servicos
{
    public abstract class BaseServicos<TEntidade> : IDisposable, IBaseServicos<TEntidade> where TEntidade : class
    {
        private readonly IBaseRepositorio<TEntidade> _repositorio;

        protected BaseServicos(IBaseRepositorio<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Inserir(TEntidade obj)
        {
            _repositorio.Inserir(obj);
        }

        public void Atualizar(TEntidade obj)
        {
            _repositorio.Atualizar(obj);
        }

        public void Mesclar(TEntidade obj)
        {
            _repositorio.Mesclar(obj);
        }

        public void Remover(TEntidade obj)
        {
            _repositorio.Remover(obj);
        }

        public void InserirEmMassa(IEnumerable<TEntidade> obj)
        {
            _repositorio.InserirEmMassa(obj);
        }

        public void AtualizarEmMassa(IEnumerable<TEntidade> obj)
        {
            _repositorio.AtualizarEmMassa(obj);
        }

        public void MesclarEmMassa(IEnumerable<TEntidade> obj)
        {
            _repositorio.MesclarEmMassa(obj);
        }

        public void RemoverEmMassa(IEnumerable<TEntidade> obj)
        {
            _repositorio.RemoverEmMassa(obj);
        }

        public TEntidade ObterPorChave(object chave)
        {
            return _repositorio.ObterPorChave(chave);
        }

        public TEntidade ObterPorChave(object[] chave)
        {
            return _repositorio.ObterPorChave(chave);
        }

        public object Contar()
        {
            return _repositorio.Contar();
        }

        public object Contar(Expression<Func<TEntidade, bool>> condicoes)
        {
            return _repositorio.Contar(condicoes);
        }

        public IEnumerable<TEntidade> Listar(bool emCache = false)
        {
            return _repositorio.Listar(emCache);
        }

        public IEnumerable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes, bool emCache = false)
        {
            return _repositorio.Listar(condicoes, emCache);
        }

        public IEnumerable<TEntidade> Listar(int deslocamento, int limite, bool emCache = false)
        {
            return _repositorio.Listar(deslocamento, limite, emCache);
        }

        public IEnumerable<TEntidade> Listar(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, bool emCache = false)
        {
            return _repositorio.Listar(deslocamento, limite, condicoes, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarAsc(ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarAsc(condicoes, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarAsc(deslocamento, limite, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarAsc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarAsc(deslocamento, limite, condicoes, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarDesc(ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarDesc(condicoes, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarDesc(deslocamento, limite, ordenarPor, emCache);
        }

        public IEnumerable<TEntidade> ListarDesc<TChave>(int deslocamento, int limite, Expression<Func<TEntidade, bool>> condicoes, Expression<Func<TEntidade, TChave>> ordenarPor, bool emCache = false)
        {
            return _repositorio.ListarDesc(deslocamento, limite, condicoes, ordenarPor, emCache);
        }

        public void AtivarRestricoes()
        {
            _repositorio.AtivarRestricoes();
        }

        public void DesativarRestricoes()
        {
            _repositorio.DesativarRestricoes();
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