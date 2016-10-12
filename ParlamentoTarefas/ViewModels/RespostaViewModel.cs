using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace ParlamentoTarefas.ViewModels
{
    public class RespostaViewModel<TEntity> where TEntity : class
    {
        [JsonProperty("CodigoStatus")]
        public HttpStatusCode CodigoStatus { get; set; }

        [JsonProperty("DescricaoStatus")]
        public string DescricaoStatus { get; set; }

        [JsonProperty("MensagemErro", NullValueHandling = NullValueHandling.Ignore)]
        public string MensagemErro { get; set; }

        [JsonProperty("Conteudo", NullValueHandling = NullValueHandling.Ignore)]
        public TEntity Conteudo { get; set; }

        public RespostaViewModel(IRestResponse resposta)
        {
            CodigoStatus = resposta.StatusCode;
            DescricaoStatus = resposta.StatusDescription;

            try
            {
                Conteudo = JsonConvert.DeserializeObject<TEntity>(resposta.Content);
            }
            catch (Exception ex)
            {
                MensagemErro = ex.Message;
            }
        }
    }
}