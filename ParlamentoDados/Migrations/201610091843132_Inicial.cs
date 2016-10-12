namespace ParlamentoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercicios",
                c => new
                    {
                        CodigoExercicio = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        CodigoMandato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoExercicio)
                .ForeignKey("dbo.Mandatos", t => t.CodigoMandato)
                .Index(t => t.CodigoMandato);
            
            CreateTable(
                "dbo.Mandatos",
                c => new
                    {
                        CodigoMandato = c.Int(nullable: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        NumeroPrimeiraLegislatura = c.Int(nullable: false),
                        NumeroSegundaLegislatura = c.Int(nullable: false),
                        DescricaoParticipacao = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.CodigoMandato)
                .ForeignKey("dbo.Legislaturas", t => t.NumeroSegundaLegislatura)
                .ForeignKey("dbo.Legislaturas", t => t.NumeroPrimeiraLegislatura)
                .Index(t => t.NumeroPrimeiraLegislatura)
                .Index(t => t.NumeroSegundaLegislatura);
            
            CreateTable(
                "dbo.Legislaturas",
                c => new
                    {
                        NumeroLegislatura = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroLegislatura);
            
            CreateTable(
                "dbo.Suplentes",
                c => new
                    {
                        CodigoParlamentar = c.Int(nullable: false),
                        DescricaoParticipacao = c.String(maxLength: 255, unicode: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        CodigoMandato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoParlamentar)
                .ForeignKey("dbo.Mandatos", t => t.CodigoMandato)
                .Index(t => t.CodigoMandato);
            
            CreateTable(
                "dbo.Identificacoes",
                c => new
                    {
                        CodigoParlamentar = c.Int(nullable: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        NomeCompleto = c.String(maxLength: 255, unicode: false),
                        Sexo = c.String(maxLength: 255, unicode: false),
                        FormaTratamento = c.String(maxLength: 255, unicode: false),
                        UrlFoto = c.String(maxLength: 255, unicode: false),
                        UrlPagina = c.String(maxLength: 255, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        SiglaPartido = c.String(maxLength: 10, unicode: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.CodigoParlamentar);
            
            CreateTable(
                "dbo.Parlamentares",
                c => new
                    {
                        CodigoIdentificacao = c.Int(nullable: false),
                        CodigoMandato = c.Int(nullable: false),
                        UrlGlossario = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodigoIdentificacao, t.CodigoMandato })
                .ForeignKey("dbo.Identificacoes", t => t.CodigoIdentificacao)
                .ForeignKey("dbo.Mandatos", t => t.CodigoMandato)
                .Index(t => t.CodigoIdentificacao)
                .Index(t => t.CodigoMandato);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parlamentares", "CodigoMandato", "dbo.Mandatos");
            DropForeignKey("dbo.Parlamentares", "CodigoIdentificacao", "dbo.Identificacoes");
            DropForeignKey("dbo.Exercicios", "CodigoMandato", "dbo.Mandatos");
            DropForeignKey("dbo.Suplentes", "CodigoMandato", "dbo.Mandatos");
            DropForeignKey("dbo.Mandatos", "NumeroPrimeiraLegislatura", "dbo.Legislaturas");
            DropForeignKey("dbo.Mandatos", "NumeroSegundaLegislatura", "dbo.Legislaturas");
            DropIndex("dbo.Parlamentares", new[] { "CodigoMandato" });
            DropIndex("dbo.Parlamentares", new[] { "CodigoIdentificacao" });
            DropIndex("dbo.Suplentes", new[] { "CodigoMandato" });
            DropIndex("dbo.Mandatos", new[] { "NumeroSegundaLegislatura" });
            DropIndex("dbo.Mandatos", new[] { "NumeroPrimeiraLegislatura" });
            DropIndex("dbo.Exercicios", new[] { "CodigoMandato" });
            DropTable("dbo.Parlamentares");
            DropTable("dbo.Identificacoes");
            DropTable("dbo.Suplentes");
            DropTable("dbo.Legislaturas");
            DropTable("dbo.Mandatos");
            DropTable("dbo.Exercicios");
        }
    }
}
