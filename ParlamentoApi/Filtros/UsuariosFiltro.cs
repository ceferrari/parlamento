using ParlamentoDominio.Entidades;
using System;
using System.Linq.Expressions;

namespace ParlamentoApi.Filtros
{
    public class UsuariosFiltro : BaseFiltro<Usuario>
    {
        public override Expression<Func<Usuario, bool>> Condicoes()
        {
            return null;
        }
    }
}