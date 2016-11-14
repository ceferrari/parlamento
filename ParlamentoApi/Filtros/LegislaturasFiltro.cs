using ParlamentoApi.Recursos;
using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class LegislaturasFiltro : BaseFiltro<Legislatura>
    {
        public override Expression<Func<Legislatura, bool>> Condicoes()
        {
            return null;
        }
    }
}