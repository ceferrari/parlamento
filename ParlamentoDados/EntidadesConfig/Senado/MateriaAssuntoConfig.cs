using ParlamentoDominio.Entidades.Senado;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Senado
{
    public class MateriaAssuntoConfig : EntityTypeConfiguration<MateriaAssunto>
    {
        public MateriaAssuntoConfig()
        {
            ToTable("MateriasAssuntos");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}