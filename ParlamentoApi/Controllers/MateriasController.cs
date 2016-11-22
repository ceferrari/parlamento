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
    /// Métodos referetes às Matérias votadas pelo Senado
    /// </summary>
    public class MateriasController : ApiController
    {
        private readonly IMateriasServicosApp _servicosApp;

        public MateriasController(IMateriasServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }

        /// <summary>
        /// Conta as Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Contar([FromUri]MateriasFiltro filtro)
        {
            var quantidade = _servicosApp.Contar(filtro.Condicoes());

            return Request.CreateResponse(HttpStatusCode.OK, quantidade);
        }

        /// <summary>
        /// Lista as Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Listar([FromUri]MateriasFiltro filtro)
        {
            var lista = _servicosApp.Listar(filtro.Condicoes(), filtro.ordenarPor, filtro.deslocamento, filtro.limite);

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Lista os Anos distintos das Matérias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListarAnos()
        {
            var lista = _servicosApp.ListarAnos();

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Obtém uma Matéria pelo código
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
        /// Insere uma Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]Materia entidade)
        {
            _servicosApp.Inserir(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Insere em massa uma lista de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<Materia> lista)
        {
            _servicosApp.InserirEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza uma Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Atualizar([FromBody]Materia entidade)
        {
            _servicosApp.Atualizar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza em massa uma lista de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarEmMassa([FromBody]IEnumerable<Materia> lista)
        {
            _servicosApp.AtualizarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove uma Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Remover([FromBody]Materia entidade)
        {
            _servicosApp.Remover(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove em massa uma lista de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoverEmMassa([FromBody]IEnumerable<Materia> lista)
        {
            _servicosApp.RemoverEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla uma Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Mesclar([FromBody]Materia entidade)
        {
            _servicosApp.Mesclar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla em massa uma lista de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MesclarEmMassa([FromBody]IEnumerable<Materia> lista)
        {
            _servicosApp.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        ///// <summary>
        ///// Trunca a tabela de Matérias no banco de dados
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public HttpResponseMessage TruncarTabela()
        //{
        //    _servicosApp.TruncarTabela("Materias");

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }
}