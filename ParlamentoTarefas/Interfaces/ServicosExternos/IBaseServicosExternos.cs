using System.Collections.Generic;
using RestSharp;

namespace ParlamentoTarefas.Interfaces.ServicosExternos
{
    public interface IBaseServicosExternos
    {
        Parameter CriarParametro(string nome, object valor);

        IRestResponse Executar(string recurso, Method metodo, List<Parameter> parametros = null, object body = null);
    }
}