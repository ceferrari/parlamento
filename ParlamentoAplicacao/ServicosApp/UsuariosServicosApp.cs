using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Entidades;
using ParlamentoDominio.Interfaces.Servicos;

namespace ParlamentoAplicacao.ServicosApp
{
    public class UsuariosServicosApp : BaseServicosApp<Usuario>, IUsuariosServicosApp
    {
        private readonly IUsuariosServicos _servicos;

        public UsuariosServicosApp(IUsuariosServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}