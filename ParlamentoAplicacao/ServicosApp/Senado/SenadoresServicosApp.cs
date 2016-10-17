using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class SenadoresServicosApp : BaseServicosApp<Senador>, ISenadoresServicosApp
    {
        private readonly ISenadoresServicos _servicos;

        public SenadoresServicosApp(ISenadoresServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}