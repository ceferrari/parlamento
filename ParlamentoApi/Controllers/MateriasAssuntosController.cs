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
    /// Métodos referetes aos Assuntos de Matérias votadas pelo Senado
    /// </summary>
    public class MateriasAssuntosController : ApiController
    {
        private readonly IMateriasAssuntosServicosApp _servicosApp;

        public MateriasAssuntosController(IMateriasAssuntosServicosApp servicosApp)
        {
            _servicosApp = servicosApp;
        }

        /// <summary>
        /// Conta os Assuntos de Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Contar([FromUri]MateriasAssuntosFiltro filtro)
        {
            var quantidade = _servicosApp.Contar(filtro.Condicoes());

            return Request.CreateResponse(HttpStatusCode.OK, quantidade);
        }

        /// <summary>
        /// Lista os Assuntos de Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Listar([FromUri]MateriasAssuntosFiltro filtro)
        {
            var lista = _servicosApp.Listar(filtro.Condicoes(), filtro.ordenarPor, filtro.deslocamento, filtro.limite);

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Lista os Assuntos Gerais de Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListarGerais()
        {
            var lista = _servicosApp.ListarGerais();

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Lista os Assuntos Específicos de Matérias com base nos parâmetros fornecidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListarEspecificos()
        {
            var lista = _servicosApp.ListarEspecificos();

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        /// <summary>
        /// Obtém um Assunto de Matéria pelo código
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
        /// Insere um Assunto de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]MateriaAssunto entidade)
        {
            _servicosApp.Inserir(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Insere em massa uma lista de Assuntos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<MateriaAssunto> lista)
        {
            _servicosApp.InserirEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um Assunto de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Atualizar([FromBody]MateriaAssunto entidade)
        {
            _servicosApp.Atualizar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza em massa uma lista de Assuntos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarEmMassa([FromBody]IEnumerable<MateriaAssunto> lista)
        {
            _servicosApp.AtualizarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove um Assunto de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Remover([FromBody]MateriaAssunto entidade)
        {
            _servicosApp.Remover(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Remove em massa uma lista de Assuntos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RemoverEmMassa([FromBody]IEnumerable<MateriaAssunto> lista)
        {
            _servicosApp.RemoverEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla um Assunto de Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Mesclar([FromBody]MateriaAssunto entidade)
        {
            _servicosApp.Mesclar(entidade);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Mescla em massa uma lista de Assuntos de Matérias
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage MesclarEmMassa([FromBody]IEnumerable<MateriaAssunto> lista)
        {
            _servicosApp.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Trunca a tabela de Assuntos de Matérias no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage TruncarTabela()
        {
            _servicosApp.TruncarTabela("MateriasAssuntos");

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}