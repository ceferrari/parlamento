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
    /// Métodos referetes aos Subtipos de Matérias votadas pelo Senado
    /// </summary>
    public class MateriasSubtiposController : ApiController
    {
        private readonly IMateriasSubtiposServicosApp _servicosApp;

        public MateriasSubtiposController(IMateriasSubtiposServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }

        /// <summary>
        /// Conta os Subtipos de Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Contar([FromUri]MateriasSubtiposFiltro filtro)
        {
            var quantidade = _servicosApp.Contar(filtro.Condicoes());

            return Request.CreateResponse(HttpStatusCode.OK, quantidade);
        }

        /// <summary>
        /// Lista os Subtipos de Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Listar([FromUri]MateriasSubtiposFiltro filtro)
        {
            var lista = _servicosApp.Listar(filtro.Condicoes(), filtro.ordenarPor, filtro.deslocamento, filtro.limite);

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Obtém um Subtipo de Matéria pelo código
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ObterPorChave(string id)
        {
            var entidade = _servicosApp.ObterPorChave(id);

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
            _servicosApp.Inserir(entidade);

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
            _servicosApp.InserirEmMassa(lista);

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
            _servicosApp.Atualizar(entidade);

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
            _servicosApp.AtualizarEmMassa(lista);

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
            _servicosApp.Remover(entidade);

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
            _servicosApp.RemoverEmMassa(lista);

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
            _servicosApp.Mesclar(entidade);

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
            _servicosApp.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        ///// <summary>
        ///// Trunca a tabela de Subtipos de Matérias no banco de dados
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage TruncarTabela()
        //{
        //    _servicosApp.TruncarTabela("MateriasSubtipos");

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }
}