using System;
using System.Collections.Generic;

namespace ParlamentoDominio.Entidades.Parlamentares
{
    public class Legislatura
    {
        public Legislatura()
        {
            Mandatos = new List<Mandato>();
        }

        public int NumeroLegislatura { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual ICollection<Mandato> Mandatos { get; set; }
    }
}
