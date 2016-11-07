using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface ILegislaturasServicosApp : IBaseServicosApp<Legislatura>
    {
        Legislatura ObterAtual();
    }
}