using System.Collections.Generic;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface ISenadoresServicos : IBaseServicos<Senador>
    {
        IEnumerable<string> ListarPartidos();
        IEnumerable<string> ListarEstados();
        IEnumerable<string> ListarSexos();
    }
}