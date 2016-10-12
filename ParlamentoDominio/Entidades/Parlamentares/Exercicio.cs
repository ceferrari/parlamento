using System;

namespace ParlamentoDominio.Entidades.Parlamentares
{
    public class Exercicio
    {
        public int CodigoExercicio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataLeitura { get; set; }
        public string SiglaCausaAfastamento { get; set; }
        public string DescricaoCausaAfastamento { get; set; }
        public int CodigoMandato { get; set; }

        public virtual Mandato Mandato { get; set; }
    }
}