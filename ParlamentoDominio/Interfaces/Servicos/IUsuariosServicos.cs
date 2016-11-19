using ParlamentoDominio.Entidades;

namespace ParlamentoDominio.Interfaces.Servicos
{
    public interface IUsuariosServicos : IBaseServicos<Usuario>
    {
        Usuario Autenticar(string email, string senha);

        void Registrar(Usuario usuario);
    }
}