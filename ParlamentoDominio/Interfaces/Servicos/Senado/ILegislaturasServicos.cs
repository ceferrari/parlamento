using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Servicos.Senado
{
    public interface ILegislaturasServicos : IBaseServicos<Legislatura>
    {
        Legislatura ObterAtual();
    }
}