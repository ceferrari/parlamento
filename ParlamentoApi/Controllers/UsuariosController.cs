using ParlamentoApi.Filtros;
using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Entidades;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        /// <summary>
        /// Autentica um Usuário pelo e-mail e senha fornecidos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Autenticar([FromBody]Usuario usuario)
        {
            var entidade = _servicosApp.Autenticar(usuario.Email, usuario.Senha);

            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        /// <summary>
        /// Registra um Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Registrar([FromBody]Usuario usuario)
        {
            _servicosApp.Registrar(usuario);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Conta os Usuários com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Contar([FromUri]UsuariosFiltro filtro)
        {
            var quantidade = _servicosApp.Contar(filtro.Condicoes());

            return Request.CreateResponse(HttpStatusCode.OK, quantidade);
        }

        /// <summary>
        /// Lista os Usuários com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Listar([FromUri]UsuariosFiltro filtro)
        {
            var lista = _servicosApp.Listar(filtro.Condicoes(), filtro.ordenarPor, filtro.deslocamento, filtro.limite);

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Obtém um Usuário pelo código
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ObterPorChave(int id)
        {
            var entidade = _servicosApp.ObterPorChave(id);

            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        /// <summary>
        /// Insere um Usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]Usuario entidade)
        {
            _servicosApp.Inserir(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Insere em massa uma lista de Usuários
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<Usuario> lista)
        {
            _servicosApp.InserirEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um Usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Atualizar([FromBody]Usuario entidade)
        {
            _servicosApp.Atualizar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza em massa uma lista de Usuários
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarEmMassa([FromBody]IEnumerable<Usuario> lista)
        {
            _servicosApp.AtualizarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove um Usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Remover([FromBody]Usuario entidade)
        {
            _servicosApp.Remover(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove em massa uma lista de Usuários
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoverEmMassa([FromBody]IEnumerable<Usuario> lista)
        {
            _servicosApp.RemoverEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla um Usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Mesclar([FromBody]Usuario entidade)
        {
            _servicosApp.Mesclar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla em massa uma lista de Usuários
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MesclarEmMassa([FromBody]IEnumerable<Usuario> lista)
        {
            _servicosApp.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Trunca a tabela de Usuários no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage TruncarTabela()
        {
            _servicosApp.TruncarTabela("Usuarios");

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}