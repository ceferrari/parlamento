using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class SenadorConfig : EntityTypeConfiguration<Senador>
    {
        public SenadorConfig()
        {
            ToTable("Senadores");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.SiglaPartido)
                .HasMaxLength(10);

            Property(t => t.UfMandato)
                .HasMaxLength(2);

            Property(t => t.UfNascimento)
                .HasMaxLength(2);

            Property(t => t.UfNascimento)
                .HasMaxLength(10);

            HasRequired(t => t.PrimeiraLegislatura)
                .WithMany()
                .HasForeignKey(t => t.CodigoPrimeiraLegislatura);

            HasRequired(t => t.SegundaLegislatura)
                .WithMany()
                .HasForeignKey(t => t.CodigoSegundaLegislatura);
        }
    }
}