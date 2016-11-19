using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface ISenadoresServicosApp : IBaseServicosApp<Senador>
    {
        IEnumerable<string> ListarPartidos();
        IEnumerable<string> ListarEstados();
        IEnumerable<string> ListarSexos();
    }
}