using ParlamentoDominio.Entidades.Senado;
using System.Linq;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface ISenadoresServicos : IBaseServicos<Senador>
    {
        IQueryable<string> ListarPartidos();
        IQueryable<string> ListarEstados();
        IQueryable<string> ListarSexos();
    }
}