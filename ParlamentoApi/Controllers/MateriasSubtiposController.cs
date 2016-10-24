using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParlamentoApi.Controllers
{
    /// <summary>
    /// Métodos referetes aos Subtipos de Matérias votadas pelo Senado
    /// </summary>
    public class MateriasSubtiposController : ApiController
    {
        private const string OrdenarPor = "Codigo";
        private readonly IMateriasSubtiposServicosApp _svc;

        public MateriasSubtiposController(IMateriasSubtiposServicosApp svc)
        {
            _svc = svc;
        }

        /// <summary>
        /// Conta os Subtipos de Matérias com base nas condições fornecidas
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
        /// Lista os Subtipos de Matérias com base nas condições fornecidas
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
        /// Lista os Subtipos de Matérias com base nas condições fornecidas e com paginação
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
        /// Obtém um Subtipo de Matéria pelo código
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ObterPorCodigo(string id)
        {
            var entidade = _svc.ObterPorCodigo(id);

            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        /// <summary>
        /// Insere um Subtipo de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]MateriaSubtipo entidade)
        {
            _svc.Inserir(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Insere em massa uma lista de Subtipos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<MateriaSubtipo> lista)
        {
            _svc.InserirEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um Subtipo de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Atualizar([FromBody]MateriaSubtipo entidade)
        {
            _svc.Atualizar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza em massa uma lista de Subtipos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarEmMassa([FromBody]IEnumerable<MateriaSubtipo> lista)
        {
            _svc.AtualizarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove um Subtipo de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Remover([FromBody]MateriaSubtipo entidade)
        {
            _svc.Remover(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove em massa uma lista de Subtipos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoverEmMassa([FromBody]IEnumerable<MateriaSubtipo> lista)
        {
            _svc.RemoverEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla um Subtipo de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Mesclar([FromBody]MateriaSubtipo entidade)
        {
            _svc.Mesclar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla em massa uma lista de Subtipos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MesclarEmMassa([FromBody]IEnumerable<MateriaSubtipo> lista)
        {
            _svc.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}