using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Parlamentares
{
    public class MandatoViewModel
    {
        public MandatoViewModel()
        {
            Suplentes = new List<SuplenteViewModel>();
            Exercicios = new List<ExercicioViewModel>();
        }

        public int CodigoMandato { get; set; }
        public string UfParlamentar { get; set; }
        public LegislaturaViewModel PrimeiraLegislaturaDoMandato { get; set; }
        public LegislaturaViewModel SegundaLegislaturaDoMandato { get; set; }
        public string DescricaoParticipacao { get; set; }
        public virtual ICollection<SuplenteViewModel> Suplentes { get; set; }
        public virtual ICollection<ExercicioViewModel> Exercicios { get; set; }
    }
}
