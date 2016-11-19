using ParlamentoDominio.Entidades;
using ParlamentoDominio.Interfaces.Repositorios;
using ParlamentoDominio.Interfaces.Servicos;
using ParlamentoDominio.Recursos;
using System;

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

        public Usuario Autenticar(string email, string senha)
        {
            var senhaEncriptada = SimpleAES.Encrypt(senha);
            
            return _repositorio.ObterPorEmailSenha(email, senhaEncriptada);
        }

        public void Registrar(Usuario usuario)
        {
            if (Autenticar(usuario.Email, usuario.Senha) != null)
            {
                throw new Exception("Usuário já cadastrado no sistema.");
            }

            usuario.Id = Guid.NewGuid();
            usuario.Senha = SimpleAES.Encrypt(usuario.Senha);

            _repositorio.Inserir(usuario);
        }
    }
}