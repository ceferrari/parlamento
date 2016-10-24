using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class ListaMateriasAssuntosViewModel
    {
        public ListaMateriasAssuntosViewModelListaAssuntos ListaAssuntos { get; set; }
    }

    public class ListaMateriasAssuntosViewModelListaAssuntos
    {
        public ListaMateriasAssuntosViewModelMetadados Metadados { get; set; }
        public ListaMateriasAssuntosViewModelAssuntos Assuntos { get; set; }
    }

    public class ListaMateriasAssuntosViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class ListaMateriasAssuntosViewModelAssuntos
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ListaMateriasAssuntosViewModelAssunto>))]
        public IList<ListaMateriasAssuntosViewModelAssunto> Assunto { get; set; }
    }

    public class ListaMateriasAssuntosViewModelAssunto
    {
        public string Codigo { get; set; }
        public string AssuntoGeral { get; set; }
        public string AssuntoEspecifico { get; set; }
        public string DataInicio { get; set; }
    }
}