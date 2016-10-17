using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class ParlamentarViewModel
    {
        public ParlamentarViewModelParlamentar parlamentar { get; set; }
    }

    public class ParlamentarViewModelParlamentar
    {
        public string idParlamentar { get; set; }
        public string idDeputado { get; set; }
        public string nomeCompleto { get; set; }
        public string nomeParlamentar { get; set; }
        public string sexoParlamentar { get; set; }
        public string dataNascimento { get; set; }
        public string diaNascimento { get; set; }
        public string mesNascimento { get; set; }
        public string anoNascimento { get; set; }
        public string nomeCidadeNatural { get; set; }
        public string siglaUfNatural { get; set; }
        public string DescricaoPaisNascimento { get; set; }
        public string CodigoEstadoCivil { get; set; }
        public string local { get; set; }
        public string fone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public ParlamentarViewModelLicencas licencas { get; set; }
        public ParlamentarViewModelNomesParlamentares nomesParlamentares { get; set; }
        public ParlamentarViewModelObservacoes observacoes { get; set; }
        public ParlamentarViewModelLiderancas liderancas { get; set; }
        public ParlamentarViewModelFiliacoes filiacoes { get; set; }
        public ParlamentarViewModelExercicios exercicios { get; set; }
        public string _id { get; set; }
    }

    public class ParlamentarViewModelLicencas
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ParlamentarViewModelLicenca>))]
        public IList<ParlamentarViewModelLicenca> licenca { get; set; }
    }

    public class ParlamentarViewModelLicenca
    {
        public string idLicenca { get; set; }
        public string idParlamentar { get; set; }
        public string dataInicio { get; set; }
        public string dataTermino { get; set; }
        public string tipoAfastamento { get; set; }
        public string descricaoFinalidade { get; set; }
        public string dataLeitura { get; set; }
        public string tipoDocumento { get; set; }
        public string descricaoNumDocumento { get; set; }
        public string siglaOrgaoLicenca { get; set; }
        public string _id { get; set; }
        public string indicadorPaisExterior { get; set; }
        public string dataPedido { get; set; }
        public string dataAutorizacaoPlenario { get; set; }
        public string dataInicioPrevista { get; set; }
        public string dataTerminoPrevista { get; set; }
    }

    public class ParlamentarViewModelNomesParlamentares
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ParlamentarViewModelNomeParlamentar>))]
        public IList<ParlamentarViewModelNomeParlamentar> nomeParlamentar { get; set; }
    }

    public class ParlamentarViewModelNomeParlamentar
    {
        public string idParlamentar { get; set; }
        public string nomeParlamentar { get; set; }
        public string dataInicio { get; set; }
        public string _id { get; set; }
    }

    public class ParlamentarViewModelObservacoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ParlamentarViewModelObservacao>))]
        public IList<ParlamentarViewModelObservacao> observacao { get; set; }
    }

    public class ParlamentarViewModelObservacao
    {
        public string idObservacao { get; set; }
        public string idParlamentar { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public string observacao { get; set; }
        public string _id { get; set; }
    }

    public class ParlamentarViewModelLiderancas
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ParlamentarViewModelLideranca>))]
        public IList<ParlamentarViewModelLideranca> lideranca { get; set; }
    }

    public class ParlamentarViewModelLideranca
    {
        public string idLideranca { get; set; }
        public string idParlamentar { get; set; }
        public string siglaCasa { get; set; }
        public string tipoUnidLideranca { get; set; }
        public string tipoLideranca { get; set; }
        public string dataDesignacao { get; set; }
        public string _id { get; set; }
        public string idUnidLideranca { get; set; }
        public string idUnidPartd { get; set; }
        public ParlamentarViewModelUnidadeLideranca unidadeLideranca { get; set; }
        public string mumeroOrdemViceLider { get; set; }
        public string dataTermino { get; set; }
    }

    public class ParlamentarViewModelUnidadeLideranca
    {
        public string ordem { get; set; }
        public string idPartido { get; set; }
        public string siglaPartido { get; set; }
        public string nomePartido { get; set; }
        public string dataCriacaoPartido { get; set; }
    }

    public class ParlamentarViewModelFiliacoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ParlamentarViewModelFiliacao>))]
        public IList<ParlamentarViewModelFiliacao> filiacao { get; set; }
    }

    public class ParlamentarViewModelFiliacao
    {
        public string idFiliacao { get; set; }
        public string idParlamentar { get; set; }
        public string idPartido { get; set; }
        public ParlamentarViewModelPartido partido { get; set; }
        public string dataFiliacao { get; set; }
        public string _id { get; set; }
    }

    public class ParlamentarViewModelPartido
    {
        public string siglaPartido { get; set; }
        public string nomePartido { get; set; }
        public string dataCriacao { get; set; }
    }

    public class ParlamentarViewModelExercicios
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ParlamentarViewModelExercicio>))]
        public IList<ParlamentarViewModelExercicio> exercicio { get; set; }
    }

    public class ParlamentarViewModelExercicio
    {
        public string idExercicio { get; set; }
        public string idParlamentar { get; set; }
        public string idMandato { get; set; }
        public ParlamentarViewModelMandato mandato { get; set; }
        public string dataInicio { get; set; }
        public string _id { get; set; }
    }

    public class ParlamentarViewModelMandato
    {
        public string idTitular { get; set; }
        public string siglaCasa { get; set; }
        public string siglaUf { get; set; }
        public string numeroLegislaturaInicio { get; set; }
        public string mumeroLegislaturaFim { get; set; }
    }
}