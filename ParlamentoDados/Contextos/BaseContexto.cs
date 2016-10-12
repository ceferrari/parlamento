using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ParlamentoDados.EntidadesConfig;
using ParlamentoDados.EntidadesConfig.Parlamentares;
using ParlamentoDominio.Entidades;
using ParlamentoDominio.Entidades.Parlamentares;

namespace ParlamentoDados.Contextos
{
    public class BaseContexto : DbContext
    {
        static BaseContexto()
        {
            Database.SetInitializer<BaseContexto>(null);
        }

        public BaseContexto() 
            : base("BaseConexao")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Identificacao> Identificacoes { get; set; }
        public DbSet<Legislatura> Legislaturas { get; set; }
        public DbSet<Mandato> Mandatos { get; set; }
        public DbSet<Parlamentar> Parlamentares { get; set; }
        public DbSet<Suplente> Suplentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("VARCHAR"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new ExercicioConfig());
            modelBuilder.Configurations.Add(new IdentificacaoConfig());
            modelBuilder.Configurations.Add(new LegislaturaConfig());
            modelBuilder.Configurations.Add(new MandatoConfig());
            modelBuilder.Configurations.Add(new ParlamentarConfig());
            modelBuilder.Configurations.Add(new SuplenteConfig());
        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Data") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("Data").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("Data").IsModified = false;
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}