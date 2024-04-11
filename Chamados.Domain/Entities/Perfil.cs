using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Domain.Entities
{
    public class Perfil
    {
        private Perfil()
        {
        }

        public static Perfil AdicionarPerfil(String Descricao)
        {
            if (string.IsNullOrWhiteSpace(Descricao))
                throw new ArgumentException("A descrição não pode ser nula ou vazia.", nameof(Descricao));

            var Perfil = new Perfil
            {
                _id = Guid.NewGuid(),
                _descricao = Descricao
            };

            return Perfil;
        }

        public void AtualizarPerfil(String Descricao)
        {
            if (string.IsNullOrWhiteSpace(Descricao))
                throw new ArgumentException("A descrição não pode ser nula ou vazia.", nameof(Descricao));

            _descricao = Descricao;
        }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            private set { _descricao = value; }
        }


    }
}
