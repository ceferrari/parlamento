using System;
using System.Collections.Generic;

namespace ParlamentoDominio.Entidades.Senado
{
    public class Senador
    {
        public int Codigo { get; set; }
        public string FormaTratamento { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string SiglaPartido { get; set; }
        public string UfMandato { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CidadeNascimento { get; set; }
        public string UfNascimento { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string UrlFoto { get; set; }
        public string UrlPagina { get; set; }
        public bool EmExercicio { get; set; }
        public int CodigoPrimeiraLegislatura { get; set; }
        public int CodigoSegundaLegislatura { get; set; }

        public virtual Legislatura PrimeiraLegislatura { get; set; }
        public virtual Legislatura SegundaLegislatura { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }
    }
}