using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class VotosFiltro : BaseFiltro<Voto>
    {
        public int? Senador { get; set; }
        public int? Materia { get; set; }
        public int? Sessao { get; set; }
        public int? AutorMateria { get; set; }
        public string AssuntoGeralMateria { get; set; }
        public int? AssuntoEspecificoMateria { get; set; }
        public string SubtipoMateria { get; set; }
        public string DescricaoVoto { get; set; }

        public override Expression<Func<Voto, bool>> Condicoes()
        {
            Expression<Func<Voto, bool>> condicoes = PredicateBuilder.True<Voto>();

            if (Senador != null)
            {
                condicoes = condicoes.And(x => x.CodigoSenador == Senador);
            }

            if (Materia != null)
            {
                condicoes = condicoes.And(x => x.CodigoMateria == Materia);
            }

            if (Sessao != null)
            {
                condicoes = condicoes.And(x => x.CodigoSessao == Sessao);
            }

            if (AutorMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoAutor == AutorMateria);
            }

            if (AssuntoGeralMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.Assunto.AssuntoGeral.Equals(AssuntoGeralMateria));
            }

            if (AssuntoEspecificoMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoAssunto == AssuntoEspecificoMateria);
            }

            if (SubtipoMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoSubtipo.Equals(SubtipoMateria));
            }

            if (DescricaoVoto != null)
            {
                if (string.Equals(DescricaoVoto, "Ausente", StringComparison.OrdinalIgnoreCase))
                {
                    Expression<Func<Voto, bool>> ausente = PredicateBuilder.False<Voto>();

                    ausente = ausente.Or(x => x.DescricaoVoto.Equals("AP"));
                    ausente = ausente.Or(x => x.DescricaoVoto.Equals("LP"));
                    ausente = ausente.Or(x => x.DescricaoVoto.Equals("LS"));
                    ausente = ausente.Or(x => x.DescricaoVoto.Equals("MIS"));
                    ausente = ausente.Or(x => x.DescricaoVoto.Equals("NCom"));
                    ausente = ausente.Or(x => x.DescricaoVoto.Equals("REP"));

                    condicoes = condicoes.And(ausente);
                }
                else
                {
                    condicoes = condicoes.And(x => x.DescricaoVoto.Equals(DescricaoVoto));
                }
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}