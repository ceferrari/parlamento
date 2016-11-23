using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class MateriasFiltro : BaseFiltro<Materia>
    {
        public int? Ano { get; set; }
        public int? Autor { get; set; }
        public string AssuntoGeral { get; set; }
        public int? AssuntoEspecifico { get; set; }
        public string Subtipo { get; set; }
        public string Ementa { get; set; }

        public override Expression<Func<Materia, bool>> Condicoes()
        {
            Expression<Func<Materia, bool>> condicoes = PredicateBuilder.True<Materia>();

            if (Ano != null)
            {
                condicoes = condicoes.And(x => x.Ano == Ano);
            }

            if (Autor != null)
            {
                condicoes = condicoes.And(x => x.CodigoAutor == Autor);
            }

            if (AssuntoGeral != null)
            {
                condicoes = condicoes.And(x => x.Assunto.AssuntoGeral.Equals(AssuntoGeral));
            }

            if (AssuntoEspecifico != null)
            {
                condicoes = condicoes.And(x => x.CodigoAssunto == AssuntoEspecifico);
            }

            if (Subtipo != null)
            {
                condicoes = condicoes.And(x => x.CodigoSubtipo.Equals(Subtipo));
            }

            if (Ementa != null)
            {
                condicoes = condicoes.And(x => x.Ementa.Contains(Ementa));
            }

            return condicoes.Body.NodeType == ExpressionType.Constant ? null : condicoes;
        }
    }
}