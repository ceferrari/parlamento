using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class MateriasFiltro : BaseFiltro<Materia>
    {
        public int? ano { get; set; }
        public int? autor { get; set; }
        public string assuntoGeral { get; set; }
        public int? assuntoEspecifico { get; set; }
        public string subtipo { get; set; }

        public override Expression<Func<Materia, bool>> Condicoes()
        {
            Expression<Func<Materia, bool>> condicoes = PredicateBuilder.True<Materia>();

            if (ano != null)
            {
                condicoes = condicoes.And(x => x.Ano == ano);
            }

            if (autor != null)
            {
                condicoes = condicoes.And(x => x.CodigoAutor == autor);
            }

            if (assuntoGeral != null)
            {
                condicoes = condicoes.And(x => x.Assunto.AssuntoGeral.Equals(assuntoGeral));
            }

            if (assuntoEspecifico != null)
            {
                condicoes = condicoes.And(x => x.CodigoAssunto == assuntoEspecifico);
            }

            if (subtipo != null)
            {
                condicoes = condicoes.And(x => x.CodigoSubtipo.Equals(subtipo));
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}