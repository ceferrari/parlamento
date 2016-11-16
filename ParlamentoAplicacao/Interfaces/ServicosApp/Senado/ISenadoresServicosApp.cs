using System.Collections.Generic;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface ISenadoresServicosApp : IBaseServicosApp<Senador>
    {
        IEnumerable<string> ListarPartidos();
        IEnumerable<string> ListarEstados();
        IEnumerable<string> ListarSexos();
    }
}