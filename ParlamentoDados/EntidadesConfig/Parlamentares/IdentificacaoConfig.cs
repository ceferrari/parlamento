using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ParlamentoDominio.Entidades.Parlamentares;

namespace ParlamentoDados.EntidadesConfig.Parlamentares
{
    public class IdentificacaoConfig : EntityTypeConfiguration<Identificacao>
    {
        public IdentificacaoConfig()
        {
            ToTable("Identificacoes");

            HasKey(t => t.CodigoParlamentar);

            Property(t => t.CodigoParlamentar)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.SiglaPartido)
                .HasMaxLength(10);

            Property(t => t.Uf)
                .HasMaxLength(2);
        }
    }
}
