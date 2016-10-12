namespace ParlamentoDominio.Entidades.Parlamentares
{
    public class Identificacao
    {
        public int CodigoParlamentar { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string Sexo { get; set; }
        public string FormaTratamento { get; set; }
        public string UrlFoto { get; set; }
        public string UrlPagina { get; set; }
        public string Email { get; set; }
        public string SiglaPartido { get; set; }
        public string Uf { get; set; }
    }
}
