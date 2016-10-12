using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParlamentoAplicacao.Interfaces.ServicosApp;
using ParlamentoDominio.Entidades;

namespace ParlamentoApi.Controllers
{
    public class ExemplosController : ApiController
    {
        private readonly IExemplosServicosApp _exemplos;

        public ExemplosController(IExemplosServicosApp exemplos)
        {
            _exemplos = exemplos;
        }

        [HttpGet]
        [ActionName("Listar")]
        public HttpResponseMessage Listar()
        {
            var listaExemplos = _exemplos.ListarEmMemoria();

            return Request.CreateResponse(HttpStatusCode.OK, listaExemplos);
        }

        [HttpPost]
        [ActionName("InserirEmMassa")]
        public HttpResponseMessage InserirEmMassa([FromBody]IEnumerable<Exemplo> exemplos)
        {
            _exemplos.InserirEmMassa(exemplos);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
