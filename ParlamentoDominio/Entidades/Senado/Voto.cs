namespace ParlamentoDominio.Entidades.Senado
{
    public class Voto
    {
        public int CodigoSenador { get; set; }
        public int CodigoSessao { get; set; }
        public int CodigoMateria { get; set; }
        public string DescricaoVoto { get; set; }

        public virtual Senador Senador { get; set; }
        public virtual Votacao Votacao { get; set; }
    }
}