using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParlamentoApi.Controllers
{
    /// <summary>
    /// Métodos referetes aos Senadores
    /// </summary>
    public class SenadoresController : ApiController
    {
        private const string OrdenarPor = "Nome";
        private readonly ISenadoresServicosApp _svc;

        public SenadoresController(ISenadoresServicosApp svc)
        {
            _svc = svc;
        }

        /// <summary>
        /// Conta os Senadores com base nas condições fornecidas
        /// </summary>
        /// <param name="condicoes"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Contar(string condicoes = null)
        {
            var quantidade = _svc.Contar(condicoes);

            return Request.CreateResponse(HttpStatusCode.OK, quantidade);
        }

        /// <summary>
        /// Lista os Senadores com base nas condições fornecidas
        /// </summary>
        /// <param name="condicoes"></param>
        /// <param name="ordenarPor"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Listar(string condicoes = null, string ordenarPor = OrdenarPor)
        {
            var lista = _svc.Listar(condicoes, ordenarPor);

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Lista os Senadores com base nas condições fornecidas e com paginação
        /// </summary>
        /// <param name="deslocamento"></param>
        /// <param name="limite"></param>
        /// <param name="condicoes"></param>
        /// <param name="ordenarPor"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListarPaginado(int deslocamento, int limite, string condicoes = null, string ordenarPor = OrdenarPor)
        {
            var lista = _svc.ListarPaginado(deslocamento, limite, condicoes, ordenarPor);

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Obtém um Senador pelo código
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ObterPorCodigo(int id)
        {
            var entidade = _svc.ObterPorCodigo(id);

            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        /// <summary>
        /// Insere um Senador
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]Senador entidade)
        {
            _svc.Inserir(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Insere em massa uma lista de Senadores
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<Senador> lista)
        {
            _svc.InserirEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um Senador
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Atualizar([FromBody]Senador entidade)
        {
            _svc.Atualizar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza em massa uma lista de Senadores
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarEmMassa([FromBody]IEnumerable<Senador> lista)
        {
            _svc.AtualizarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove um Senador
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Remover([FromBody]Senador entidade)
        {
            _svc.Remover(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove em massa uma lista de Senadores
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoverEmMassa([FromBody]IEnumerable<Senador> lista)
        {
            _svc.RemoverEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla um Senador
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Mesclar([FromBody]Senador entidade)
        {
            _svc.Mesclar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla em massa uma lista de Senadores
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MesclarEmMassa([FromBody]IEnumerable<Senador> lista)
        {
            _svc.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}