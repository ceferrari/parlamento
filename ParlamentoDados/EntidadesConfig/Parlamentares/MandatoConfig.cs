using ParlamentoDominio.Entidades.Parlamentares;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Parlamentares
{
    public class MandatoConfig : EntityTypeConfiguration<Mandato>
    {
        public MandatoConfig()
        {
            ToTable("Mandatos");

            HasKey(t => t.CodigoMandato);

            Property(t => t.CodigoMandato)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Uf)
                .HasMaxLength(2);

            HasRequired(t => t.PrimeiraLegislatura)
                .WithMany()
                .HasForeignKey(t => t.NumeroPrimeiraLegislatura);

            HasRequired(t => t.SegundaLegislatura)
                .WithMany()
                .HasForeignKey(t => t.NumeroSegundaLegislatura);
        }
    }
}