namespace ParlamentoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Legislaturas",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        DataEleicao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        Ementa = c.String(maxLength: 8000, unicode: false),
                        ExplicacaoEmenta = c.String(maxLength: 8000, unicode: false),
                        CodigoAutor = c.Int(nullable: false),
                        CodigoAssunto = c.Int(nullable: false),
                        CodigoSubtipo = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.MateriasAssuntos", t => t.CodigoAssunto)
                .ForeignKey("dbo.MateriasSubtipos", t => t.CodigoSubtipo)
                .Index(t => t.CodigoAssunto)
                .Index(t => t.CodigoSubtipo);
            
            CreateTable(
                "dbo.MateriasAssuntos",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        AssuntoGeral = c.String(maxLength: 255, unicode: false),
                        AssuntoEspecifico = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.MateriasSubtipos",
                c => new
                    {
                        Codigo = c.String(nullable: false, maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Senadores",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        FormaTratamento = c.String(maxLength: 255, unicode: false),
                        Nome = c.String(maxLength: 255, unicode: false),
                        NomeCompleto = c.String(maxLength: 255, unicode: false),
                        SiglaPartido = c.String(maxLength: 10, unicode: false),
                        UfMandato = c.String(maxLength: 2, unicode: false),
                        CodigoPrimeiraLegislatura = c.Int(nullable: false),
                        CodigoSegundaLegislatura = c.Int(nullable: false),
                        DataNascimento = c.DateTime(),
                        CidadeNascimento = c.String(maxLength: 255, unicode: false),
                        UfNascimento = c.String(maxLength: 10, unicode: false),
                        Sexo = c.String(maxLength: 255, unicode: false),
                        Endereco = c.String(maxLength: 255, unicode: false),
                        Telefone = c.String(maxLength: 255, unicode: false),
                        Fax = c.String(maxLength: 255, unicode: false),
                        Email = c.String(maxLength: 255, unicode: false),
                        UrlFoto = c.String(maxLength: 255, unicode: false),
                        UrlPagina = c.String(maxLength: 255, unicode: false),
                        EmExercicio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Legislaturas", t => t.CodigoPrimeiraLegislatura)
                .ForeignKey("dbo.Legislaturas", t => t.CodigoSegundaLegislatura)
                .Index(t => t.CodigoPrimeiraLegislatura)
                .Index(t => t.CodigoSegundaLegislatura);
            
            CreateTable(
                "dbo.Votacoes",
                c => new
                    {
                        CodigoSessao = c.Int(nullable: false),
                        CodigoMateria = c.Int(nullable: false),
                        Data = c.String(maxLength: 255, unicode: false),
                        HoraInicio = c.String(maxLength: 255, unicode: false),
                        IndicadorVotacaoSecreta = c.String(maxLength: 255, unicode: false),
                        DescricaoVotacao = c.String(maxLength: 255, unicode: false),
                        DescricaoResultado = c.String(maxLength: 255, unicode: false),
                        TotalVotosSim = c.String(maxLength: 255, unicode: false),
                        TotalVotosNao = c.String(maxLength: 255, unicode: false),
                        TotalVotosAbstencao = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodigoSessao, t.CodigoMateria });
            
            CreateTable(
                "dbo.Votos",
                c => new
                    {
                        CodigoSenador = c.Int(nullable: false),
                        CodigoMateria = c.Int(nullable: false),
                        CodigoSessao = c.Int(nullable: false),
                        DescricaoVoto = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => new { t.CodigoSenador, t.CodigoMateria })
                .ForeignKey("dbo.Materias", t => t.CodigoMateria)
                .ForeignKey("dbo.Senadores", t => t.CodigoSenador)
                .Index(t => t.CodigoSenador)
                .Index(t => t.CodigoMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votos", "CodigoSenador", "dbo.Senadores");
            DropForeignKey("dbo.Votos", "CodigoMateria", "dbo.Materias");
            DropForeignKey("dbo.Senadores", "CodigoSegundaLegislatura", "dbo.Legislaturas");
            DropForeignKey("dbo.Senadores", "CodigoPrimeiraLegislatura", "dbo.Legislaturas");
            DropForeignKey("dbo.Materias", "CodigoSubtipo", "dbo.MateriasSubtipos");
            DropForeignKey("dbo.Materias", "CodigoAssunto", "dbo.MateriasAssuntos");
            DropIndex("dbo.Votos", new[] { "CodigoMateria" });
            DropIndex("dbo.Votos", new[] { "CodigoSenador" });
            DropIndex("dbo.Senadores", new[] { "CodigoSegundaLegislatura" });
            DropIndex("dbo.Senadores", new[] { "CodigoPrimeiraLegislatura" });
            DropIndex("dbo.Materias", new[] { "CodigoSubtipo" });
            DropIndex("dbo.Materias", new[] { "CodigoAssunto" });
            DropTable("dbo.Votos");
            DropTable("dbo.Votacoes");
            DropTable("dbo.Senadores");
            DropTable("dbo.MateriasSubtipos");
            DropTable("dbo.MateriasAssuntos");
            DropTable("dbo.Materias");
            DropTable("dbo.Legislaturas");
        }
    }
}
