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

            HasKey(t => new { t.CodigoSenador, t.CodigoMateria, t.CodigoSessao });

            Property(t => t.CodigoSenador)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoSessao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoMateria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.DescricaoVoto);

            HasRequired(t => t.Senador)
                .WithMany(t => t.Votos)
                .HasForeignKey(t => t.CodigoSenador);

            HasRequired(t => t.Materia)
                .WithMany()
                .HasForeignKey(t => t.CodigoMateria);
        }
    }
}