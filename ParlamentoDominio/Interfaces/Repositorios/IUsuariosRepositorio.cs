using ParlamentoDominio.Entidades;

namespace ParlamentoDominio.Interfaces.Repositorios
{
    public interface IUsuariosRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario ObterPorEmailSenha(string email, string senha);
    }
}