using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ParlamentoDominio.Entidades.Parlamentares;

namespace ParlamentoDados.EntidadesConfig.Parlamentares
{
    public class SuplenteConfig : EntityTypeConfiguration<Suplente>
    {
        public SuplenteConfig()
        {
            ToTable("Suplentes");

            HasKey(t => t.CodigoParlamentar);

            Property(t => t.CodigoParlamentar)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Mandato)
                .WithMany(t => t.Suplentes)
                .HasForeignKey(t => t.CodigoMandato);
        }
    }
}