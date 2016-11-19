using ParlamentoDominio.Entidades;
using ParlamentoDominio.Interfaces.Repositorios;
using System.Linq;

namespace ParlamentoDados.Repositorios
{
    public class UsuariosRepositorio : BaseRepositorio<Usuario>, IUsuariosRepositorio
    {
        public Usuario ObterPorEmailSenha(string email, string password)
        {
            return Db.Set<Usuario>().FirstOrDefault(x => x.Email.Equals(email) && x.Senha.Equals(password));
        }
    }
}