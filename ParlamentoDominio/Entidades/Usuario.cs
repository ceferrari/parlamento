using System;

namespace ParlamentoDominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}