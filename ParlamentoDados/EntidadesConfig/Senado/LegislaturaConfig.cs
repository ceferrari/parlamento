using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class LegislaturaConfig : EntityTypeConfiguration<Legislatura>
    {
        public LegislaturaConfig()
        {
            ToTable("Legislaturas");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}