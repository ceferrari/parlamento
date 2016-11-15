using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class SenadoresFiltro : BaseFiltro<Senador>
    {
        public string siglaPartido { get; set; }
        public string ufMandato { get; set; }
        public int? codigoPrimeiraLegislatura { get; set; }
        public int? codigoSegundaLegislatura { get; set; }
        public string sexo { get; set; }
        public bool? emExercicio { get; set; }

        public override Expression<Func<Senador, bool>> Condicoes()
        {
            Expression<Func<Senador, bool>> condicoes = PredicateBuilder.True<Senador>();

            if (siglaPartido != null)
            {
                condicoes = condicoes.And(x => x.SiglaPartido.Equals(siglaPartido));
            }

            if (ufMandato != null)
            {
                condicoes = condicoes.And(x => x.UfMandato.Equals(ufMandato));
            }

            if (codigoPrimeiraLegislatura != null)
            {
                condicoes = condicoes.And(x => x.CodigoPrimeiraLegislatura == codigoPrimeiraLegislatura);
            }

            if (codigoSegundaLegislatura != null)
            {
                condicoes = condicoes.And(x => x.CodigoSegundaLegislatura == codigoSegundaLegislatura);
            }

            if (sexo != null)
            {
                condicoes = condicoes.And(x => x.Sexo.Equals(sexo));
            }

            if (emExercicio != null)
            {
                condicoes = condicoes.And(x => x.EmExercicio == emExercicio);
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}