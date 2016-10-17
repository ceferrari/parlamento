using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class VotacaoConfig : EntityTypeConfiguration<Votacao>
    {
        public VotacaoConfig()
        {
            ToTable("Votacoes");

            HasKey(t => new { t.CodigoSessao, t.CodigoMateria });

            Property(t => t.CodigoSessao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoMateria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}