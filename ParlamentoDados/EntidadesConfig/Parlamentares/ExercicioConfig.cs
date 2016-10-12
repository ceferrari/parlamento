using ParlamentoDominio.Entidades.Parlamentares;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ParlamentoDados.EntidadesConfig.Parlamentares
{
    public class ExercicioConfig : EntityTypeConfiguration<Exercicio>
    {
        public ExercicioConfig()
        {
            ToTable("Exercicios");

            HasKey(t => t.CodigoExercicio);

            Property(t => t.CodigoExercicio)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Mandato)
                .WithMany(t => t.Exercicios)
                .HasForeignKey(t => t.CodigoMandato);
        }
    }
}
