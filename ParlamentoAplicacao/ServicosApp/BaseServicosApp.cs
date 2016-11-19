using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Dispose()
        {
            _servicos.Dispose();
        }

        public void AtivarRestricoes()
        {
            _servicos.AtivarRestricoes();
        }

        public void DesativarRestricoes()
        {
            _servicos.DesativarRestricoes();
        }

        public void TruncarTabela(string tabela)
        {
            _servicos.TruncarTabela(tabela);
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

        public object Contar(Expression<Func<TEntidade, bool>> condicoes = null)
        {
            return _servicos.Contar(condicoes);
        }

        public IQueryable<TEntidade> Listar(Expression<Func<TEntidade, bool>> condicoes = null,
            string ordenarPor = null, int deslocamento = -1, int limite = -1, bool noContexto = false)
        {
            return _servicos.Listar(condicoes, ordenarPor, deslocamento, limite, noContexto);
        }
    }
}