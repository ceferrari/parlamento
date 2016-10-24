namespace ParlamentoDominio.Entidades.Senado
{
    public class Materia
    {
        public int Codigo { get; set; }
        public int Ano { get; set; }
        public string Ementa { get; set; }
        public string ExplicacaoEmenta { get; set; }
        public int CodigoAutor { get; set; }
        public int CodigoAssunto { get; set; }
        public string CodigoSubtipo { get; set; }

        public virtual MateriaAssunto Assunto { get; set; }
        public virtual MateriaSubtipo Subtipo { get; set; }
    }
}