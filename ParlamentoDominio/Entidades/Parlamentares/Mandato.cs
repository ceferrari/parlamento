using System.Collections.Generic;

namespace ParlamentoDominio.Entidades.Parlamentares
{
    public class Mandato
    {
        public Mandato()
        {
            Suplentes = new List<Suplente>();
            Exercicios = new List<Exercicio>();
        }

        public int CodigoMandato { get; set; }
        public string Uf { get; set; }
        public int NumeroPrimeiraLegislatura { get; set; }
        public int NumeroSegundaLegislatura { get; set; }
        public string DescricaoParticipacao { get; set; }
        

        public virtual Legislatura PrimeiraLegislatura { get; set; }
        public virtual Legislatura SegundaLegislatura { get; set; }
        public virtual ICollection<Suplente> Suplentes { get; set; }
        public virtual ICollection<Exercicio> Exercicios { get; set; }
    }
}
