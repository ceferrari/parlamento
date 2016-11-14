using ParlamentoAplicacao.Interfaces.ServicosApp;
using System.Web.Http;

namespace ParlamentoApi.Controllers
{
    /// <summary>
    /// Métodos referetes aos Usuários da aplicação
    /// </summary>
    public class UsuariosController : ApiController
    {
        private readonly IUsuariosServicosApp _servicosApp;

        public UsuariosController(IUsuariosServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }
    }
}