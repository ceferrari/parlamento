using System.Collections.Generic;
using ParlamentoTarefas.ViewModels;

namespace ParlamentoTarefas.Interfaces.ServicosExternos
{
    public interface IExemplosServicosExternos : IBaseServicosExternos
    {
        RespostaViewModel<IEnumerable<ExemploViewModel>> ListarExemplos();
    }
}
