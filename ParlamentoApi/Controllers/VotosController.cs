using ParlamentoApi.Filtros;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParlamentoApi.Controllers
{
    /// <summary>
    /// Métodos referetes aos Votos dos Senadores
    /// </summary>
    public class VotosController : ApiController
    {
        private readonly IVotosServicosApp _servicosApp;

        public VotosController(IVotosServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }

        /// <summary>
        /// Conta os Votos com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Contar([FromUri]VotosFiltro filtro)
        {
            var quantidade = _servicosApp.Contar(filtro.Condicoes());

            return Request.CreateResponse(HttpStatusCode.OK, quantidade);
        }

        /// <summary>
        /// Lista os Votos com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Listar([FromUri]VotosFiltro filtro)
        {
            var lista = _servicosApp.Listar(filtro.Condicoes(), filtro.ordenarPor, filtro.deslocamento, filtro.limite);
            
            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Insere um Voto
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]Voto entidade)
        {
            _servicosApp.Inserir(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Insere em massa uma lista de Votos
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<Voto> lista)
        {
            _servicosApp.InserirEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um Voto
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Atualizar([FromBody]Voto entidade)
        {
            _servicosApp.Atualizar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza em massa uma lista de Votos
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarEmMassa([FromBody]IEnumerable<Voto> lista)
        {
            _servicosApp.AtualizarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove um Voto
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Remover([FromBody]Voto entidade)
        {
            _servicosApp.Remover(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove em massa uma lista de Votos
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoverEmMassa([FromBody]IEnumerable<Voto> lista)
        {
            _servicosApp.RemoverEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla um Voto
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Mesclar([FromBody]Voto entidade)
        {
            _servicosApp.Mesclar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla em massa uma lista de Votos
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MesclarEmMassa([FromBody]IEnumerable<Voto> lista)
        {
            _servicosApp.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        ///// <summary>
        ///// Trunca a tabela de Votos no banco de dados
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage TruncarTabela()
        //{
        //    _servicosApp.TruncarTabela("Votos");

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }
}