using Newtonsoft.Json;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class ListaSenadoresViewModel
    {
        public ListaSenadoresViewModelListaParlamentarEmExercicio ListaParlamentarEmExercicio { get; set; }
    }

    public class ListaSenadoresViewModelListaParlamentarEmExercicio
    {
        public ListaSenadoresViewModelMetadados Metadados { get; set; }
        public ListaSenadoresViewModelParlamentares Parlamentares { get; set; }
    }

    public class ListaSenadoresViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class ListaSenadoresViewModelParlamentares
    {
        public IList<ListaSenadoresViewModelParlamentar> Parlamentar { get; set; }
    }

    public class ListaSenadoresViewModelParlamentar
    {
        public ListaSenadoresViewModelIdentificacaoParlamentar IdentificacaoParlamentar { get; set; }
        public ListaSenadoresViewModelMandato Mandato { get; set; }
        public string UrlGlossario { get; set; }
    }
    
    public class ListaSenadoresViewModelIdentificacaoParlamentar
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

    public class ListaSenadoresViewModelMandato
    {
        public string CodigoMandato { get; set; }
        public string UfParlamentar { get; set; }
        public ListaSenadoresViewModelLegislaturaDoMandato PrimeiraLegislaturaDoMandato { get; set; }
        public ListaSenadoresViewModelLegislaturaDoMandato SegundaLegislaturaDoMandato { get; set; }
        public string DescricaoParticipacao { get; set; }
        public ListaSenadoresViewModelSuplentes Suplentes { get; set; }
        public ListaSenadoresViewModelExercicios Exercicios { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ListaSenadoresViewModelTitular Titular { get; set; }
    }

    public class ListaSenadoresViewModelLegislaturaDoMandato
    {
        public string NumeroLegislatura { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
    }

    public class ListaSenadoresViewModelSuplentes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaSenadoresViewModelSuplente>))]
        public IList<ListaSenadoresViewModelSuplente> Suplente { get; set; }
    }

    public class ListaSenadoresViewModelSuplente
    {
        public string DescricaoParticipacao { get; set; }
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
    }

    public class ListaSenadoresViewModelExercicios
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaSenadoresViewModelExercicio>))]
        public IList<ListaSenadoresViewModelExercicio> Exercicio { get; set; }
    }

    public class ListaSenadoresViewModelExercicio
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

    public class ListaSenadoresViewModelTitular
    {
        public string DescricaoParticipacao { get; set; }
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
    }
}