using System;

namespace ParlamentoDominio.Entidades.Senado
{
    public class Legislatura
    {
        public int Codigo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? DataEleicao { get; set; }
    }
}