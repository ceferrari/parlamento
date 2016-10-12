namespace ParlamentoDominio.Entidades.Parlamentares
{
    public class Parlamentar
    {
        public int CodigoIdentificacao { get; set; }
        public int CodigoMandato { get; set; }
        public string UrlGlossario { get; set; }

        public virtual Identificacao Identificacao { get; set; }
        public virtual Mandato Mandato { get; set; }
    }
}
