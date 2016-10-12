using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Parlamentares
{
    public class ListaParlamentarViewModel
    {
        public ListaParlamentarEmExercicioViewModel ListaParlamentarEmExercicio { get; set; }
    }

    public class ListaParlamentarEmExercicioViewModel
    {
        public ParlamentaresViewModel Parlamentares { get; set; }
    }

    public class ParlamentaresViewModel
    {
        public List<ParlamentarViewModel> Parlamentar { get; set; }
    }
}