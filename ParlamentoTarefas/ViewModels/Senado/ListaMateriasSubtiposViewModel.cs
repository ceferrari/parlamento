using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class ListaMateriasSubtiposViewModel
    {
        public ListaMateriasSubtiposViewModelListaSubtiposMateria ListaSubtiposMateria { get; set; }
    }

    public class ListaMateriasSubtiposViewModelListaSubtiposMateria
    {
        public ListaMateriasSubtiposViewModelMetadados Metadados { get; set; }
        public ListaMateriasSubtiposViewModelSubtiposMateria SubtiposMateria { get; set; }
    }

    public class ListaMateriasSubtiposViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class ListaMateriasSubtiposViewModelSubtiposMateria
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaMateriasSubtiposViewModelSubtipoMateria>))]
        public IList<ListaMateriasSubtiposViewModelSubtipoMateria> SubtipoMateria { get; set; }
    }

    public class ListaMateriasSubtiposViewModelSubtipoMateria
    {
        public string SiglaMateria { get; set; }
        public string DescricaoSubtipoMateria { get; set; }
        public string DataCriacao { get; set; }
        public string IndicadorProposicao { get; set; }
    }
}