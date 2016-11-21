using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class VotosFiltro : BaseFiltro<Voto>
    {
        public int? senador { get; set; }
        public int? materia { get; set; }
        public int? sessao { get; set; }
        public int? autorMateria { get; set; }
        public string assuntoGeralMateria { get; set; }
        public int? assuntoEspecificoMateria { get; set; }
        public string subtipoMateria { get; set; }
        public string descricaoVoto { get; set; }

        public override Expression<Func<Voto, bool>> Condicoes()
        {
            Expression<Func<Voto, bool>> condicoes = PredicateBuilder.True<Voto>();

            if (senador != null)
            {
                condicoes = condicoes.And(x => x.CodigoSenador == senador);
            }

            if (materia != null)
            {
                condicoes = condicoes.And(x => x.CodigoMateria == materia);
            }

            if (sessao != null)
            {
                condicoes = condicoes.And(x => x.CodigoSessao == sessao);
            }

            if (autorMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoAutor == autorMateria);
            }

            if (assuntoGeralMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.Assunto.AssuntoGeral.Equals(assuntoGeralMateria));
            }

            if (assuntoEspecificoMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoAssunto == assuntoEspecificoMateria);
            }

            if (subtipoMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoSubtipo.Equals(subtipoMateria));
            }

            if (descricaoVoto != null)
            {
                if (string.Equals(descricaoVoto, "Ausente", StringComparison.OrdinalIgnoreCase))
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
                    condicoes = condicoes.And(x => x.DescricaoVoto.Equals(descricaoVoto));
                }
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}