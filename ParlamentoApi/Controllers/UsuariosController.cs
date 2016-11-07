using ParlamentoAplicacao.Interfaces.ServicosApp;
using System.Web.Http;

namespace ParlamentoApi.Controllers
{
    /// <summary>
    /// Métodos referetes aos Usuários da aplicação
    /// </summary>
    public class UsuariosController : ApiController
    {
        private const string OrdenarPor = "CodigoSenador,CodigoMateria,CodigoSessao";
        private readonly IUsuariosServicosApp _svc;

        public UsuariosController(IUsuariosServicosApp svc)
        {
            _svc = svc;
        }
    }
}