using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Entidades;
using ParlamentoDominio.Interfaces.Servicos;

namespace ParlamentoAplicacao.ServicosApp
{
    public class ExemplosServicosApp : BaseServicosApp<Exemplo>, IExemplosServicosApp
    {
        private readonly IExemplosServicos _servicos;

        public ExemplosServicosApp(IExemplosServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}