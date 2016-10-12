namespace ParlamentoDominio.Entidades.Parlamentares
{
    public class Suplente
    {
        public string DescricaoParticipacao { get; set; }
        public int CodigoParlamentar { get; set; }
        public string Nome { get; set; }
        public int CodigoMandato { get; set; }

        public virtual Mandato Mandato { get; set; }
    }
}
