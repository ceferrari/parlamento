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
            var exception = context.Exception;
            var message = exception.Message;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                message = exception.Message;
            }

            var resposta = new RestResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                StatusDescription = "Internal Server Error",
                Content = message
            };

            var retorno = context.Request.CreateResponse
            (
                resposta.StatusCode,
                new RespostaViewModel<string>(resposta)
            );

            context.Result = new ResponseMessageResult(retorno);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}