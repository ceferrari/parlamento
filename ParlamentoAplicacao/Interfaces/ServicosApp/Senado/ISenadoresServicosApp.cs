using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;
using System.Linq;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface ISenadoresServicosApp : IBaseServicosApp<Senador>
    {
        IQueryable<string> ListarPartidos();
        IQueryable<string> ListarEstados();
        IQueryable<string> ListarSexos();
    }
}