using Chamados.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.Querys.Usuarios
{
    public class ObterUsuarioPorIdQuery : IRequest<Usuario>
    {
        public Guid Id { get; set; }
    }
}
