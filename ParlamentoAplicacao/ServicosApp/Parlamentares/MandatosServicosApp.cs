using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoAplicacao.ServicosApp.Parlamentares
{
    public class MandatosServicosApp : BaseServicosApp<Mandato>, IMandatosServicosApp
    {
        private readonly IMandatosServicos _servicos;

        public MandatosServicosApp(IMandatosServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}
