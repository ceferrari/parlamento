using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.ViewModels;
using ParlamentoTarefas.ViewModels.Senado;
using RestSharp;

namespace ParlamentoTarefas.ServicosExternos
{
    public class SenadoServicosExternos : BaseServicosExternos, ISenadoServicosExternos
    {
        public SenadoServicosExternos()
            : base ("http://legis.senado.leg.br/dadosabertos")
        {
        }

        public RespostaViewModel<ListaLegislaturasViewModel> ListarLegislaturas()
        {
            var recurso = "plenario/lista/legislaturas";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ListaLegislaturasViewModel>(resposta);
        }

        public RespostaViewModel<ListaMateriasViewModel> ListarMaterias()
        {
            var recurso = "materia/legislaturaatual";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ListaMateriasViewModel>(resposta);
        }

        public RespostaViewModel<ListaMateriasAssuntosViewModel> ListarMateriasAssuntos()
        {
            var recurso = "materia/assuntos";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ListaMateriasAssuntosViewModel>(resposta);
        }

        public RespostaViewModel<ListaMateriasSubtiposViewModel> ListarMateriasSubtipos()
        {
            var recurso = "materia/subtipos";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ListaMateriasSubtiposViewModel>(resposta);
        }

        public RespostaViewModel<MateriaViewModel> ObterMateriaPorCodigo(string codigo)
        {
            var recurso = "materia/completa/" + codigo;
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<MateriaViewModel>(resposta);
        }

        public RespostaViewModel<ListaSenadoresLegislaturaViewModel> ListarSenadoresPorLegislatura(string codigoLegislatura)
        {
            var recurso = "senador/lista/legislatura/" + codigoLegislatura;
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ListaSenadoresLegislaturaViewModel>(resposta);
        }

        public RespostaViewModel<ListaSenadoresViewModel> ListarSenadoresEmExercicio()
        {
            var recurso = "senador/lista/atual";
            var resposta = Executar(recurso, Method.GET);
            
            return new RespostaViewModel<ListaSenadoresViewModel>(resposta);
        }

        public RespostaViewModel<SenadorViewModel> ObterSenadorPorCodigo(string codigo)
        {
            var recurso = "senador/" + codigo;
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<SenadorViewModel>(resposta);
        }

        public RespostaViewModel<ParlamentarViewModel> ObterParlamentarPorCodigo(string codigo)
        {
            var recurso = "parlamentar/" + codigo;
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<ParlamentarViewModel>(resposta);
        }

        public RespostaViewModel<VotacaoViewModel> ObterVotacaoPorCodigo(string codigo)
        {
            var recurso = "senador/" + codigo + "/votacoes";
            var resposta = Executar(recurso, Method.GET);

            return new RespostaViewModel<VotacaoViewModel>(resposta);
        }
    }
}