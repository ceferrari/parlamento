using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.ViewModels;
using RestSharp;
using System.Collections.Generic;
using ParlamentoTarefas.ViewModels.Parlamentares;

namespace ParlamentoTarefas.ServicosExternos
{
    public class SenadoServicosExternos : BaseServicosExternos, ISenadoServicosExternos
    {
        public SenadoServicosExternos(string baseUrl)
            : base ("http://legis.senado.leg.br/dadosabertos")
        {
        }

        public RespostaViewModel<ListaParlamentarViewModel> ListarSenadores()
        {
            var recurso = "senador/lista/atual";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ListaParlamentarViewModel>(resposta);
        }
    }
}