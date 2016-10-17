using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class MateriaConfig : EntityTypeConfiguration<Materia>
    {
        public MateriaConfig()
        {
            ToTable("Materias");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.ExplicacaoEmenta)
                .HasMaxLength(8000);

            Property(t => t.CodigoSubtipo)
                .HasMaxLength(10);

            HasRequired(t => t.Autor)
                .WithMany()
                .HasForeignKey(t => t.CodigoAutor);

            HasRequired(t => t.Assunto)
                .WithMany()
                .HasForeignKey(t => t.CodigoAssunto);

            HasRequired(t => t.Subtipo)
                .WithMany()
                .HasForeignKey(t => t.CodigoSubtipo);
        }
    }
}