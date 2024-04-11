using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Domain.Entities
{
    public class Usuario
    {
        private Usuario()
        {
        }

        public void AtualizarUsuario(string novoNome, string novoCpf, string novoEmail, Guid novoPerfilId, bool novoAtivo)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(Nome));
            
            if (string.IsNullOrWhiteSpace(novoCpf))
                throw new ArgumentException("O CPF não pode ser nulo ou vazio.", nameof(Cpf));

            if (string.IsNullOrWhiteSpace(novoEmail))
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(Email));

            Nome = novoNome;
            Cpf = novoCpf;
            Email = novoEmail;
            PerfilId = novoPerfilId;
            Ativo = novoAtivo;
        }

        public static Usuario AdicionarUsuario(string nome, string cpf, string email, Guid perfilId, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser nulo ou vazio.", nameof(nome));

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O CPF não pode ser nulo ou vazio.", nameof(cpf));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(email));

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Cpf = cpf,
                Email = email,
                PerfilId = perfilId,
                Ativo = ativo
            };

            return usuario;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public Guid PerfilId { get; private set; }
        public virtual Perfil Perfil { get; private set; }
        public bool Ativo { get; private set; }
    }
}
