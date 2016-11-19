using ParlamentoDominio.Entidades;

namespace ParlamentoAplicacao.Interfaces.ServicosApp
{
    public interface IUsuariosServicosApp : IBaseServicosApp<Usuario>
    {
        Usuario Autenticar(string email, string senha);

        void Registrar(Usuario usuario);
    }
}