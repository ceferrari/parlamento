using ParlamentoDominio.Entidades.Parlamentares;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Parlamentares
{
    public class LegislaturaConfig : EntityTypeConfiguration<Legislatura>
    {
        public LegislaturaConfig()
        {
            ToTable("Legislaturas");

            HasKey(t => t.NumeroLegislatura);

            Property(t => t.NumeroLegislatura)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasMany(t => t.Mandatos)
                .WithRequired(t => t.PrimeiraLegislatura)
                .HasForeignKey(t => t.NumeroPrimeiraLegislatura);

            HasMany(t => t.Mandatos)
                .WithRequired(t => t.SegundaLegislatura)
                .HasForeignKey(t => t.NumeroSegundaLegislatura);
        }
    }
}