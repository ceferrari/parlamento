using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class SenadoresFiltro : BaseFiltro<Senador>
    {
        public string nome { get; set; }
        public string partido { get; set; }
        public string estado { get; set; }
        public int? primeiraLeg { get; set; }
        public int? segundaLeg { get; set; }
        public string sexo { get; set; }
        public bool? emExercicio { get; set; }

        public override Expression<Func<Senador, bool>> Condicoes()
        {
            Expression<Func<Senador, bool>> condicoes = PredicateBuilder.True<Senador>();

            if (nome != null)
            {
                condicoes = condicoes.And(x => x.Nome.Contains(nome));
            }

            if (partido != null)
            {
                condicoes = condicoes.And(x => x.SiglaPartido.Equals(partido));
            }

            if (estado != null)
            {
                condicoes = condicoes.And(x => x.UfMandato.Equals(estado));
            }

            if (primeiraLeg != null)
            {
                condicoes = condicoes.And(x => x.CodigoPrimeiraLegislatura == primeiraLeg);
            }

            if (segundaLeg != null)
            {
                condicoes = condicoes.And(x => x.CodigoSegundaLegislatura == segundaLeg);
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