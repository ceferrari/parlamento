using Newtonsoft.Json;
using ParlamentoRecursos.Recursos;
using System.Collections.Generic;

namespace ParlamentoRecursos.ViewModels.Senado
{
    public class SenadorViewModel
    {
        public SenadorViewModelDetalheParlamentar DetalheParlamentar { get; set; }
    }

    public class SenadorViewModelDetalheParlamentar
    {
        public SenadorViewModelMetadados Metadados { get; set; }
        public SenadorViewModelParlamentar Parlamentar { get; set; }
    }

    public class SenadorViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class SenadorViewModelParlamentar
    {
        public SenadorViewModelIdentificacaoParlamentar IdentificacaoParlamentar { get; set; }
        public SenadorViewModelDadosBasicosParlamentar DadosBasicosParlamentar { get; set; }
        public SenadorViewModelMandatoAtual MandatoAtual { get; set; }
        public SenadorViewModelFiliacaoAtual FiliacaoAtual { get; set; }
        public SenadorViewModelMembroAtualComissoes MembroAtualComissoes { get; set; }
        public SenadorViewModelCargosAtuais CargosAtuais { get; set; }
        public SenadorViewModelMateriasDeAutoriaTramitando MateriasDeAutoriaTramitando { get; set; }
        public SenadorViewModelRelatoriasAtuais RelatoriasAtuais { get; set; }
        public SenadorViewModelOutrasInformacoes OutrasInformacoes { get; set; }
        public string UrlGlossario { get; set; }
    }

    public class SenadorViewModelIdentificacaoParlamentar
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

    public class SenadorViewModelDadosBasicosParlamentar
    {
        public string DataNascimento { get; set; }
        public string UfNaturalidade { get; set; }
        public string EnderecoParlamentar { get; set; }
        public string TelefoneParlamentar { get; set; }
        public string FaxParlamentar { get; set; }
    }

    public class SenadorViewModelMandatoAtual
    {
        public string CodigoMandato { get; set; }
        public string UfParlamentar { get; set; }
        public SenadorViewModelLegislaturaDoMandato PrimeiraLegislaturaDoMandato { get; set; }
        public SenadorViewModelLegislaturaDoMandato SegundaLegislaturaDoMandato { get; set; }
        public string DescricaoParticipacao { get; set; }
        public SenadorViewModelSuplentes Suplentes { get; set; }
        public SenadorViewModelExercicios Exercicios { get; set; }
    }

    public class SenadorViewModelLegislaturaDoMandato
    {
        public string NumeroLegislatura { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
    }

    public class SenadorViewModelSuplentes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelSuplente>))]
        public IList<SenadorViewModelSuplente> Suplente { get; set; }
    }

    public class SenadorViewModelSuplente
    {
        public string DescricaoParticipacao { get; set; }
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
    }

    public class SenadorViewModelExercicios
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelExercicio>))]
        public IList<SenadorViewModelExercicio> Exercicio { get; set; }
    }

    public class SenadorViewModelExercicio
    {
        public string CodigoExercicio { get; set; }
        public string DataInicio { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DataFim { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SiglaCausaAfastamento { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DescricaoCausaAfastamento { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DataLeitura { get; set; }
    }

    public class SenadorViewModelFiliacaoAtual
    {
        public SenadorViewModelPartido Partido { get; set; }
        public string DataFiliacao { get; set; }
    }

    public class SenadorViewModelPartido
    {
        public string CodigoPartido { get; set; }
        public string SiglaPartido { get; set; }
        public string NomePartido { get; set; }
    }

    public class SenadorViewModelMembroAtualComissoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelComissao>))]
        public IList<SenadorViewModelComissao> Comissao { get; set; }
    }

    public class SenadorViewModelComissao
    {
        public SenadorViewModelIdentificacaoComissao IdentificacaoComissao { get; set; }
        public string DescricaoParticipacao { get; set; }
        public string DataInicio { get; set; }
    }

    public class SenadorViewModelIdentificacaoComissao
    {
        public string CodigoComissao { get; set; }
        public string SiglaComissao { get; set; }
        public string NomeComissao { get; set; }
        public string SiglaCasaComissao { get; set; }
        public string NomeCasaComissao { get; set; }
    }

    public class SenadorViewModelCargosAtuais
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelCargoAtual>))]
        public IList<SenadorViewModelCargoAtual> CargoAtual { get; set; }
    }

    public class SenadorViewModelCargoAtual
    {
        public SenadorViewModelIdentificacaoComissao IdentificacaoComissao { get; set; }
        public string CodigoCargo { get; set; }
        public string DescricaoCargo { get; set; }
        public string DataInicio { get; set; }
    }

    public class SenadorViewModelMateriasDeAutoriaTramitando
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelMateria>))]
        public IList<SenadorViewModelMateria> Materia { get; set; }
    }

    public class SenadorViewModelMateria
    {
        public SenadorViewModelIdentificacaoMateria IdentificacaoMateria { get; set; }
        public string EmentaMateria { get; set; }
    }

    public class SenadorViewModelIdentificacaoMateria
    {
        public string CodigoMateria { get; set; }
        public string SiglaCasaIdentificacaoMateria { get; set; }
        public string NomeCasaIdentificacaoMateria { get; set; }
        public string SiglaSubtipoMateria { get; set; }
        public string DescricaoSubtipoMateria { get; set; }
        public string NumeroMateria { get; set; }
        public string AnoMateria { get; set; }
    }

    public class SenadorViewModelRelatoriasAtuais
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelRelatoria>))]
        public IList<SenadorViewModelRelatoria> Relatoria { get; set; }
    }

    public class SenadorViewModelRelatoria
    {
        public SenadorViewModelMateria Materia { get; set; }
        public SenadorViewModelIdentificacaoComissao IdentificacaoComissao { get; set; }
        public string DescricaoTipoRelator { get; set; }
        public string DataDesignacao { get; set; }
    }

    public class SenadorViewModelOutrasInformacoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<SenadorViewModelServico>))]
        public IList<SenadorViewModelServico> Servico { get; set; }
    }
    
    public class SenadorViewModelServico
    {
        public string NomeServico { get; set; }
        public string DescricaoServico { get; set; }
        public string UrlServico { get; set; }
    }
}