using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class MateriasFiltro : BaseFiltro<Materia>
    {
        public int? ano { get; set; }
        public int? codigoAutor { get; set; }
        public int? codigoAssunto { get; set; }
        public string codigoSubtipo { get; set; }

        public override Expression<Func<Materia, bool>> Condicoes()
        {
            Expression<Func<Materia, bool>> condicoes = PredicateBuilder.True<Materia>();

            if (ano != null)
            {
                condicoes = condicoes.And(x => x.Ano == ano);
            }

            if (codigoAutor != null)
            {
                condicoes = condicoes.And(x => x.CodigoAutor == codigoAutor);
            }

            if (codigoAssunto != null)
            {
                condicoes = condicoes.And(x => x.CodigoAssunto == codigoAssunto);
            }

            if (codigoSubtipo != null)
            {
                condicoes = condicoes.And(x => x.CodigoSubtipo.Equals(codigoSubtipo));
            }

            return condicoes;
        }
    }
}