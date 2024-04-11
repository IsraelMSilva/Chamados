using Chamados.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.Commands.Usuarios
{
    public class RemoverUsuarioCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
