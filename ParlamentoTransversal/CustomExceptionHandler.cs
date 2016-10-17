namespace ParlamentoTransversal
{
    public class CustomExceptionHandler
    {
        //public override void Handle(ExceptionHandlerContext context)
        //{
        //    var resposta = new RestResponse
        //    {
        //        StatusCode = HttpStatusCode.InternalServerError,
        //        StatusDescription = "Internal Server Error",
        //        Content = context.Exception.Message
        //    };

        //    var retorno = context.Request.CreateResponse
        //    (
        //        resposta.StatusCode,
        //        new RespostaViewModel<string>(resposta)
        //    );

        //    context.Result = new ResponseMessageResult(retorno);

        //    //new ErrorLogger().Log(context.Exception);
        //}

        //public override bool ShouldHandle(ExceptionHandlerContext context)
        //{
        //    return true;
        //}
    }
}