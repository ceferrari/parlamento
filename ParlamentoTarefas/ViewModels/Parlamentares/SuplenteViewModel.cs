using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Parlamentares
{
    public class SuplentesViewModel
    {

        [JsonConverter(typeof(SingleOrArrayConverter<SuplenteViewModel>))]
        public List<SuplenteViewModel> Suplente { get; set; }
    }

    public class SuplenteViewModel
    {
        public string DescricaoParticipacao { get; set; }
        public int CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
    }
}