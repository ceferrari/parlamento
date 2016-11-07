using ParlamentoDominio.Entidades;
using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Servicos;

namespace ParlamentoDominio.Servicos
{
    public class UsuariosServicos : BaseServicos<Usuario>, IUsuariosServicos
    {
        private readonly IUsuariosRepositorio _repositorio;

        public UsuariosServicos(IUsuariosRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}