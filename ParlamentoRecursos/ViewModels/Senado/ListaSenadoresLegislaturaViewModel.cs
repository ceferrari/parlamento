using Newtonsoft.Json;
using ParlamentoRecursos.Recursos;
using System.Collections.Generic;

namespace ParlamentoRecursos.ViewModels.Senado
{
    public class ListaSenadoresLegislaturaViewModel
    {
        public ListaSenadoresLegislaturaViewModelListaParlamentarLegislatura ListaParlamentarLegislatura { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelListaParlamentarLegislatura
    {
        public ListaSenadoresLegislaturaViewModelMetadados Metadados { get; set; }
        public ListaSenadoresLegislaturaViewModelParlamentares Parlamentares { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelParlamentares
    {
        public IList<ListaSenadoresLegislaturaViewModelParlamentar> Parlamentar { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelParlamentar
    {
        public ListaSenadoresLegislaturaViewModelIdentificacaoParlamentar IdentificacaoParlamentar { get; set; }
        public ListaSenadoresLegislaturaViewModelMandato Mandato { get; set; }
        public string UrlGlossario { get; set; }
    }
    
    public class ListaSenadoresLegislaturaViewModelIdentificacaoParlamentar
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

    public class ListaSenadoresLegislaturaViewModelMandato
    {
        public string CodigoMandato { get; set; }
        public string UfParlamentar { get; set; }
        public ListaSenadoresLegislaturaViewModelLegislaturaDoMandato PrimeiraLegislaturaDoMandato { get; set; }
        public ListaSenadoresLegislaturaViewModelLegislaturaDoMandato SegundaLegislaturaDoMandato { get; set; }
        public string DescricaoParticipacao { get; set; }
        public ListaSenadoresLegislaturaViewModelSuplentes Suplentes { get; set; }
        public ListaSenadoresLegislaturaViewModelExercicios Exercicios { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ListaSenadoresLegislaturaViewModelTitular Titular { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelLegislaturaDoMandato
    {
        public string NumeroLegislatura { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelSuplentes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaSenadoresLegislaturaViewModelSuplente>))]
        public IList<ListaSenadoresLegislaturaViewModelSuplente> Suplente { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelSuplente
    {
        public string DescricaoParticipacao { get; set; }
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelExercicios
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaSenadoresLegislaturaViewModelExercicio>))]
        public IList<ListaSenadoresLegislaturaViewModelExercicio> Exercicio { get; set; }
    }

    public class ListaSenadoresLegislaturaViewModelExercicio
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

    public class ListaSenadoresLegislaturaViewModelTitular
    {
        public string DescricaoParticipacao { get; set; }
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
    }
}