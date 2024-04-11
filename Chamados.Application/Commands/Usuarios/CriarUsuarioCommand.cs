using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.Commands.Usuarios
{
    public class CriarUsuarioCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public Guid PerfilId { get; set; }
        public bool Ativo { get; set; }
    }
}
