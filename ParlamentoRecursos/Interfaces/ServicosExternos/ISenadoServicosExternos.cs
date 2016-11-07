using ParlamentoRecursos.ViewModels;
using ParlamentoRecursos.ViewModels.Senado;

namespace ParlamentoRecursos.Interfaces.ServicosExternos
{
    public interface ISenadoServicosExternos : IBaseServicosExternos
    {
        RespostaViewModel<ListaLegislaturasViewModel> ListarLegislaturas();

        RespostaViewModel<ListaMateriasViewModel> ListarMaterias();
        RespostaViewModel<ListaMateriasAssuntosViewModel> ListarMateriasAssuntos();
        RespostaViewModel<ListaMateriasSubtiposViewModel> ListarMateriasSubtipos();
        RespostaViewModel<MateriaViewModel> ObterMateriaPorCodigo(string codigo);

        RespostaViewModel<ListaSenadoresLegislaturaViewModel> ListarSenadoresPorLegislatura(string codigoLegislatura);
        RespostaViewModel<ListaSenadoresViewModel> ListarSenadoresEmExercicio();
        RespostaViewModel<SenadorViewModel> ObterSenadorPorCodigo(string codigo);
        RespostaViewModel<ParlamentarViewModel> ObterParlamentarPorCodigo(string codigo);

        RespostaViewModel<VotacaoViewModel> ObterVotacaoPorCodigo(string codigo);
    }
}