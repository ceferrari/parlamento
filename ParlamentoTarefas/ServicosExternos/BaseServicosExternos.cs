using System.Collections.Generic;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using RestSharp;

namespace ParlamentoTarefas.ServicosExternos
{
    public class BaseServicosExternos : IBaseServicosExternos
    {
        private readonly RestClient _cliente;

        protected BaseServicosExternos(string baseUrl)
        {
            _cliente = new RestClient(baseUrl);
        }

        public Parameter CriarParametro(string nome, object valor)
        {
            return new Parameter()
            {
                Name = nome,
                Value = valor
            };
        }

        public IRestResponse Executar(string recurso, Method metodo,
            List<Parameter> parametros = null, object body = null)
        {
            var requisicao = new RestRequest(recurso, metodo);

            //requisicao.AddHeader("Accept", "application/json");
            //requisicao.AddHeader("Content-Type", "application/json");

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    requisicao.AddQueryParameter(parametro.Name, parametro.Value.ToString());
                }
            }

            if (body != null && metodo == Method.POST)
            {
                requisicao.AddJsonBody(body);
            }

            return _cliente.Execute(requisicao);
        }
    }
}