using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.Commands.Perfis
{
    public class AtualizarPerfilCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
