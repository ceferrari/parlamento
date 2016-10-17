using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class MateriaSubtipoConfig : EntityTypeConfiguration<MateriaSubtipo>
    {
        public MateriaSubtipoConfig()
        {
            ToTable("MateriasSubtipos");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(10);
        }
    }
}