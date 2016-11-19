using ParlamentoDominio.Entidades.Senado;
using System.Collections.Generic;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface ISenadoresServicos : IBaseServicos<Senador>
    {
        IEnumerable<string> ListarPartidos();
        IEnumerable<string> ListarEstados();
        IEnumerable<string> ListarSexos();
    }
}