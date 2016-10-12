using System.Collections.Generic;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.ViewModels;
using RestSharp;

namespace ParlamentoTarefas.ServicosExternos
{
    public class ExemplosServicosExternos : BaseServicosExternos, IExemplosServicosExternos
    {
        public ExemplosServicosExternos()
            : base("")
        {
            
        }

        public RespostaViewModel<IEnumerable<ExemploViewModel>> ListarExemplos()
        {
            var recurso = "/Exemplos/Listar";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<IEnumerable<ExemploViewModel>>(resposta);
        }
    }
}
