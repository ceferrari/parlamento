using Newtonsoft.Json;
using ParlamentoRecursos.Recursos;
using System.Collections.Generic;

namespace ParlamentoRecursos.ViewModels.Senado
{
    public class VotacaoViewModel
    {
        public VotacaoViewModelVotacaoParlamentar VotacaoParlamentar { get; set; }
    }

    public class VotacaoViewModelVotacaoParlamentar
    {
        public VotacaoViewModelMetadados Metadados { get; set; }
        public VotacaoViewModelParlamentar Parlamentar { get; set; }
    }

    public class VotacaoViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class VotacaoViewModelParlamentar
    {
        public VotacaoViewModelIdentificacaoParlamentar IdentificacaoParlamentar { get; set; }
        public VotacaoViewModelVotacoes Votacoes { get; set; }
        public string UrlGlossario { get; set; }
    }

    public class VotacaoViewModelIdentificacaoParlamentar
    {
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
        public string NomeCompletoParlamentar { get; set; }
        public string SexoParlamentar { get; set; }
        public string FormaTratamento { get; set; }
        public string UrlFotoParlamentar { get; set; }
        public string UrlPaginaParlamentar { get; set; }
        public string EmailParlamentar { get; set; }
        public string SiglaPartidoParlamentar { get; set; }
        public string UfParlamentar { get; set; }
    }

    public class VotacaoViewModelVotacoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<VotacaoViewModelVotacao>))]
        public IList<VotacaoViewModelVotacao> Votacao { get; set; }
    }

    public class VotacaoViewModelVotacao
    {
        public VotacaoViewModelSessaoPlenaria SessaoPlenaria { get; set; }
        public VotacaoViewModelIdentificacaoMateria IdentificacaoMateria { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<VotacaoViewModelTramitacao>))]
        public IList<VotacaoViewModelTramitacao> Tramitacao { get; set; }
        public string IndicadorVotacaoSecreta { get; set; }
        public string DescricaoVotacao { get; set; }
        public string DescricaoResultado { get; set; }
        public string DescricaoVoto { get; set; }
        public string TotalVotosSim { get; set; }
        public string TotalVotosNao { get; set; }
        public string TotalVotosAbstencao { get; set; }
    }

    public class VotacaoViewModelSessaoPlenaria
    {
        public string CodigoSessao { get; set; }
        public string SiglaCasaSessao { get; set; }
        public string NomeCasaSessao { get; set; }
        public string CodigoSessaoLegislativa { get; set; }
        public string SiglaTipoSessao { get; set; }
        public string NumeroSessao { get; set; }
        public string DataSessao { get; set; }
        public string HoraInicioSessao { get; set; }
    }

    public class VotacaoViewModelIdentificacaoMateria
    {
        public string CodigoMateria { get; set; }
        public string SiglaCasaIdentificacaoMateria { get; set; }
        public string NomeCasaIdentificacaoMateria { get; set; }
        public string SiglaSubtipoMateria { get; set; }
        public string DescricaoSubtipoMateria { get; set; }
        public string NumeroMateria { get; set; }
        public string AnoMateria { get; set; }
        public string IndicadorTramitando { get; set; }
    }

    public class VotacaoViewModelTramitacao
    {
        public VotacaoViewModelIdentificacaoTramitacao IdentificacaoTramitacao { get; set; }
    }

    public class VotacaoViewModelIdentificacaoTramitacao
    {
        public string CodigoTramitacao { get; set; }
        public string NumeroAutuacao { get; set; }
        public string DataTramitacao { get; set; }
        public string NumeroOrdemTramitacao { get; set; }
        public string TextoTramitacao { get; set; }
        public string IndicadorRecebimento { get; set; }
        public VotacaoViewModelOrigemTramitacao OrigemTramitacao { get; set; }
        public VotacaoViewModelDestinoTramitacao DestinoTramitacao { get; set; }
        public VotacaoViewModelSituacao Situacao { get; set; }
        public string DataRecebimento { get; set; }
    }

    public class VotacaoViewModelOrigemTramitacao
    {
        public VotacaoViewModelLocal Local { get; set; }
    }

    public class VotacaoViewModelDestinoTramitacao
    {
        public VotacaoViewModelLocal Local { get; set; }
    }

    public class VotacaoViewModelLocal
    {
        public string CodigoLocal { get; set; }
        public string TipoLocal { get; set; }
        public string SiglaCasaLocal { get; set; }
        public string NomeCasaLocal { get; set; }
        public string SiglaLocal { get; set; }
        public string NomeLocal { get; set; }
    }
    
    public class VotacaoViewModelSituacao
    {
        public string CodigoSituacao { get; set; }
        public string SiglaSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
    }
}