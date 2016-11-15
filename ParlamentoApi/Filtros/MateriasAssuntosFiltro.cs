using ParlamentoDominio.Entidades.Senado;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class MateriasAssuntosFiltro : BaseFiltro<MateriaAssunto>
    {
        public override Expression<Func<MateriaAssunto, bool>> Condicoes()
        {
            return null;
        }
    }
}