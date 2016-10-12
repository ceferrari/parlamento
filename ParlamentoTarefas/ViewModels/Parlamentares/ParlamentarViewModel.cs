namespace ParlamentoTarefas.ViewModels.Parlamentares
{
    public class ParlamentarViewModel
    {
        public virtual IdentificacaoViewModel IdentificacaoParlamentar { get; set; }
        public virtual MandatoViewModel Mandato { get; set; }
        public string UrlGlossario { get; set; }
    }
}
