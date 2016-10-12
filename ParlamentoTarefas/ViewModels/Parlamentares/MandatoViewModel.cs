namespace ParlamentoTarefas.ViewModels.Parlamentares
{
    public class MandatoViewModel
    {
        public int CodigoMandato { get; set; }
        public string UfParlamentar { get; set; }
        public LegislaturaViewModel PrimeiraLegislaturaDoMandato { get; set; }
        public LegislaturaViewModel SegundaLegislaturaDoMandato { get; set; }
        public string DescricaoParticipacao { get; set; }
        public virtual SuplentesViewModel Suplentes { get; set; }
        public virtual ExerciciosViewModel Exercicios { get; set; }
    }
}
