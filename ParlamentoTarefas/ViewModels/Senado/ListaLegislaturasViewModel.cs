using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class ListaLegislaturasViewModel
    {
        public ListaLegislaturasViewModelListaLegislatura ListaLegislatura { get; set; }
    }

    public class ListaLegislaturasViewModelListaLegislatura
    {
        public ListaLegislaturasViewModelMetadados Metadados { get; set; }
        public ListaLegislaturasViewModelLegislaturas Legislatura { get; set; }
    }

    public class ListaLegislaturasViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class ListaLegislaturasViewModelLegislaturas
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaLegislaturasViewModelLegislatura>))]
        public IList<ListaLegislaturasViewModelLegislatura> Legislatura { get; set; }
    }

    public class ListaLegislaturasViewModelLegislatura
    {
        public string NumeroLegislatura { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string DataEleicao { get; set; }
    }
}