using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class SenadoresFiltro : BaseFiltro<Senador>
    {
        public string Nome { get; set; }
        public string Partido { get; set; }
        public string Estado { get; set; }
        public int? PrimeiraLegislatura { get; set; }
        public int? SegundaLegislatura { get; set; }
        public string Sexo { get; set; }
        public bool? EmExercicio { get; set; }

        public override Expression<Func<Senador, bool>> Condicoes()
        {
            Expression<Func<Senador, bool>> condicoes = PredicateBuilder.True<Senador>();

            if (Nome != null)
            {
                condicoes = condicoes.And(x => x.Nome.Contains(Nome));
            }

            if (Partido != null)
            {
                condicoes = condicoes.And(x => x.SiglaPartido.Equals(Partido));
            }

            if (Estado != null)
            {
                condicoes = condicoes.And(x => x.UfMandato.Equals(Estado));
            }

            if (PrimeiraLegislatura != null)
            {
                condicoes = condicoes.And(x => x.CodigoPrimeiraLegislatura == PrimeiraLegislatura);
            }

            if (SegundaLegislatura != null)
            {
                condicoes = condicoes.And(x => x.CodigoSegundaLegislatura == SegundaLegislatura);
            }

            if (Sexo != null)
            {
                condicoes = condicoes.And(x => x.Sexo.Equals(Sexo));
            }

            if (EmExercicio != null)
            {
                condicoes = condicoes.And(x => x.EmExercicio == EmExercicio);
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}