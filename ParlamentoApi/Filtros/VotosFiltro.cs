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
        public int? assuntoMateria { get; set; }
        public string subtipoMateria { get; set; }

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

            if (assuntoMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoAssunto == assuntoMateria);
            }

            if (subtipoMateria != null)
            {
                condicoes = condicoes.And(x => x.Materia.CodigoSubtipo.Equals(subtipoMateria));
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}