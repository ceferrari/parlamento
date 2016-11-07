using ParlamentoDados.EntidadesConfig;
using ParlamentoDados.EntidadesConfig.Senado;
using ParlamentoDominio.Entidades;
using ParlamentoDominio.Entidades.Senado;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ParlamentoDados.Contextos
{
    public class BaseContexto : DbContext
    {
        static BaseContexto()
        {
            Database.SetInitializer<BaseContexto>(null);
        }

        public BaseContexto() 
            : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=Parlamento;Integrated Security=True")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Legislatura> Legislaturas { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaAssunto> MateriasAssuntos { get; set; }
        public DbSet<MateriaSubtipo> MateriasSubtipos { get; set; }
        public DbSet<Senador> Senadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Votacao> Votacoes { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("VARCHAR"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new LegislaturaConfig());
            modelBuilder.Configurations.Add(new MateriaAssuntoConfig());
            modelBuilder.Configurations.Add(new MateriaConfig());
            modelBuilder.Configurations.Add(new MateriaSubtipoConfig());
            modelBuilder.Configurations.Add(new SenadorConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new VotacaoConfig());
            modelBuilder.Configurations.Add(new VotoConfig());
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