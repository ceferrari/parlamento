using ParlamentoTarefas.ViewModels;
using ParlamentoTarefas.ViewModels.Parlamentares;

namespace ParlamentoTarefas.Interfaces.ServicosExternos
{
    public interface ISenadoServicosExternos : IBaseServicosExternos
    {
        RespostaViewModel<ListaParlamentarViewModel> ListarSenadores();
    }
}