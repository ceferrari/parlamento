using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface ILegislaturasRepositorio : IBaseRepositorio<Legislatura>
    {
        Legislatura ObterAtual();
    }
}