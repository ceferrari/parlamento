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
        private const string OrdenarPor = "Nome";
        private readonly IMateriasServicosApp _svc;

        public MateriasController(IMateriasServicosApp svc)
        {
            _svc = svc;
        }

        /// <summary>
        /// Conta as Matérias com base nas condições fornecidas
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
        /// Lista as Matérias com base nas condições fornecidas
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
        /// Lista as Matérias com base nas condições fornecidas e com paginação
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
        /// Obtém uma Matéria pelo código
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
        /// Insere uma Matéria
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Inserir([FromBody]Materia entidade)
        {
            _svc.Inserir(entidade);

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
            _svc.InserirEmMassa(lista);

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
            _svc.Atualizar(entidade);

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
            _svc.AtualizarEmMassa(lista);

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
            _svc.Remover(entidade);

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
            _svc.RemoverEmMassa(lista);

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
            _svc.Mesclar(entidade);

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
            _svc.MesclarEmMassa(lista);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}