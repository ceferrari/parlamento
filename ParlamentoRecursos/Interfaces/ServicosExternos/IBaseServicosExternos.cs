using RestSharp;
using System.Collections.Generic;

namespace ParlamentoRecursos.Interfaces.ServicosExternos
{
    public interface IBaseServicosExternos
    {
        Parameter CriarParametro(string nome, object valor);

        List<Parameter> CriarParametrosPaginacao(int deslocamento, int limite, string condicoes = null, string ordenarPor = null);

        IRestResponse Executar(string recurso, Method metodo, List<Parameter> parametros = null, object body = null);
    }
}