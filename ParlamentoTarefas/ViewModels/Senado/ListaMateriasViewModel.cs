using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class ListaMateriasViewModel
    {
        public ListaMateriasViewModelLegislaturaAtual ListaMateriasLegislaturaAtual { get; set; }
    }

    public class ListaMateriasViewModelLegislaturaAtual
    {
        public ListaMateriasViewModelMetadados Metadados { get; set; }
        public ListaMateriasViewModelMaterias Materias { get; set; }
    }

    public class ListaMateriasViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class ListaMateriasViewModelMaterias
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaMateriasViewModelMateria>))]
        public IList<ListaMateriasViewModelMateria> Materia { get; set; }
    }

    public class ListaMateriasViewModelMateria
    {
        public ListaMateriasViewModelIdentificacaoMateria IdentificacaoMateria { get; set; }
        public string UrlDetalheMateria { get; set; }
    }

    public class ListaMateriasViewModelIdentificacaoMateria
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
}