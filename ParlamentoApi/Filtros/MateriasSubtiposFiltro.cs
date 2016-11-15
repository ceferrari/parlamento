using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class MateriasSubtiposFiltro : BaseFiltro<MateriaSubtipo>
    {
        public override Expression<Func<MateriaSubtipo, bool>> Condicoes()
        {
            return null;
        }
    }
}