using ParlamentoRecursos.ViewModels;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ParlamentoApi.Recursos
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var resposta = new RestResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                StatusDescription = "Internal Server Error",
                Content = context.Exception.Message
            };

            var retorno = context.Request.CreateResponse
            (
                resposta.StatusCode,
                new RespostaViewModel<string>(resposta)
            );

            context.Result = new ResponseMessageResult(retorno);

            //new ErrorLogger().Log(context.Exception);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}