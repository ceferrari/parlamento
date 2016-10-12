using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.ViewModels;
using ParlamentoTarefas.ViewModels.Parlamentares;
using ParlamentoTransversal;
using RestSharp;

namespace ParlamentoTarefas.ServicosExternos
{
    public class SenadoServicosExternos : BaseServicosExternos, ISenadoServicosExternos
    {
        public SenadoServicosExternos()
            : base (UrlServicos.SenadoApi)
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