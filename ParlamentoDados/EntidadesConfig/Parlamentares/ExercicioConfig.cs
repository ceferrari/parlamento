using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ParlamentoDominio.Entidades.Parlamentares;

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
