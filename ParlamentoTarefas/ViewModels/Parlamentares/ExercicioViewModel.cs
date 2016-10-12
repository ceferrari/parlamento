using Newtonsoft.Json;
using ParlamentoTransversal;
using System;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Parlamentares
{
    public class ExerciciosViewModel
    {
        [JsonConverter(typeof(SingleOrArrayConverter<ExercicioViewModel>))]
        public List<ExercicioViewModel> Exercicio { get; set; }
    }

    public class ExercicioViewModel
    {
        public int CodigoExercicio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataLeitura { get; set; }
        public string SiglaCausaAfastamento { get; set; }
        public string DescricaoCausaAfastamento { get; set; }
    }
}