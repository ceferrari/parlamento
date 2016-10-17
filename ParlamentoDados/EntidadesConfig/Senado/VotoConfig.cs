using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class VotoConfig : EntityTypeConfiguration<Voto>
    {
        public VotoConfig()
        {
            ToTable("Votos");

            HasKey(t => new { t.CodigoSenador, t.CodigoSessao, t.CodigoMateria });

            Property(t => t.CodigoSenador)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoSessao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoMateria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Senador)
                .WithMany()
                .HasForeignKey(t => t.CodigoSenador);

            HasRequired(t => t.Votacao)
                .WithMany()
                .HasForeignKey(t => new { t.CodigoSessao, t.CodigoMateria });
        }
    }
}