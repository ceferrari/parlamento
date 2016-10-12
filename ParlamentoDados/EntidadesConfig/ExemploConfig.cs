using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ParlamentoDominio.Entidades;

namespace ParlamentoDados.EntidadesConfig
{
    public class ExemploConfig : EntityTypeConfiguration<Exemplo>
    {
        public ExemploConfig()
        {
            // Tabela
            ToTable("Exemplos");

            // Chave primária
            HasKey(t => new { t.Codigo1, t.Codigo2});

            // Propriedades
            Property(t => t.Codigo1)
                .IsRequired()
                .HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Codigo2)
                .IsRequired()
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Descricao)
                .IsOptional()
                .HasColumnOrder(2)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(120);

            Property(t => t.Data);
        }
    }
}