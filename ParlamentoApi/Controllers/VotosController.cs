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
        private const string OrdenarPor = "CodigoSenador,CodigoMateria,CodigoSessao";
        private readonly IVotosServicosApp _svc;

        public VotosController(IVotosServicosApp svc)
        {
            _svc = svc;
        }

        /// <summary>
        /// Conta os Votos com base nas condições fornecidas
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
        /// Lista os Votos com base nas condições fornecidas
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
        /// Lista os Votos com base nas condições fornecidas e com paginação
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

        ///// <summary>
        ///// Lista os Votos pelo código do Senador
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage ListarPorSenador(int id)
        //{
        //    var entidade = _svc.ListarPorSenador(id);

        //    return Request.CreateResponse(HttpStatusCode.OK, entidade);
        //}

        ///// <summary>
        ///// Lista os Votos pelo código da Matéria
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage ListarPorMateria(int id)
        //{
        //    var entidade = _svc.ListarPorMateria(id);

        //    return Request.CreateResponse(HttpStatusCode.OK, entidade);
        //}

        ///// <summary>
        ///// Lista os Votos pelo código da Sessão
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage ListarPorSessao(int id)
        //{
        //    var entidade = _svc.ListarPorSessao(id);

        //    return Request.CreateResponse(HttpStatusCode.OK, entidade);
        //}

        /// <summary>
        /// Insere um Voto
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]Voto entidade)
        {
            _svc.Inserir(entidade);

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
            _svc.InserirEmMassa(lista);

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
            _svc.Atualizar(entidade);

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
            _svc.AtualizarEmMassa(lista);

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
            _svc.Remover(entidade);

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
            _svc.RemoverEmMassa(lista);

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
            _svc.Mesclar(entidade);

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
            _svc.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}