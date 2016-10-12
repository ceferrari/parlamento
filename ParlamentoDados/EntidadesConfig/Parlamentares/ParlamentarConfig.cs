using ParlamentoDominio.Entidades.Parlamentares;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Parlamentares
{
    public class ParlamentarConfig : EntityTypeConfiguration<Parlamentar>
    {
        public ParlamentarConfig()
        {
            ToTable("Parlamentares");

            HasKey(t => new { t.CodigoIdentificacao, t.CodigoMandato });

            Property(t => t.CodigoIdentificacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoMandato)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Identificacao)
                .WithMany()
                .HasForeignKey(t => t.CodigoIdentificacao);

            HasRequired(t => t.Mandato)
                .WithMany()
                .HasForeignKey(t => t.CodigoMandato);
        }
    }
}