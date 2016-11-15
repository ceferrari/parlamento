using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class VotosFiltro : BaseFiltro<Voto>
    {
        public int? codigoSenador { get; set; }
        public int? codigoMateria { get; set; }
        public int? codigoSessao { get; set; }

        public override Expression<Func<Voto, bool>> Condicoes()
        {
            Expression<Func<Voto, bool>> condicoes = PredicateBuilder.True<Voto>();

            if (codigoSenador != null)
            {
                condicoes = condicoes.And(x => x.CodigoSenador == codigoSenador);
            }

            if (codigoMateria != null)
            {
                condicoes = condicoes.And(x => x.CodigoMateria == codigoMateria);
            }

            if (codigoSessao != null)
            {
                condicoes = condicoes.And(x => x.CodigoSessao == codigoSessao);
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}