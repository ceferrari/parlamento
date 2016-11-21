using ParlamentoRecursos.Interfaces.ServicosExternos;
using RestSharp;
using System.Collections.Generic;

namespace ParlamentoRecursos.ServicosExternos
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
            return new Parameter
            {
                Name = nome,
                Value = valor
            };
        }

        public List<Parameter> CriarParametrosPaginacao(int deslocamento, int limite,
            string condicoes = null, string ordenarPor = null)
        {
            var parametros = new List<Parameter>
            {
                CriarParametro("ordenarPor", ordenarPor),
                CriarParametro("deslocamento", deslocamento),
                CriarParametro("limite", limite)
            };

            if (!string.IsNullOrEmpty(condicoes))
            {
                parametros.Add(CriarParametro("condicoes", condicoes));
            }

            return parametros;
        }

        public IRestResponse Executar(string recurso, Method metodo,
            List<Parameter> parametros = null, object body = null)
        {
            var requisicao = new RestRequest(recurso, metodo)
            {
                RequestFormat = DataFormat.Json
            };

            //requisicao.AddHeader("Accept", "application/json");
            //requisicao.AddHeader("Content-Type", "application/json");

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    requisicao.AddQueryParameter(parametro.Name, parametro.Value.ToString());
                }
            }

            if (body != null)
            {
                requisicao.AddJsonBody(body);
            }

            return _cliente.Execute(requisicao);
        }
    }
}