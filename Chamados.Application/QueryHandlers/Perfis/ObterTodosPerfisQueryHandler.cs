using Chamados.Application.Querys.Perfis;
using Chamados.Domain.Entities;
using Chamados.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.QueryHandlers.Perfis
{
    public class ObterTodosPerfisQueryHandler : IRequestHandler<ObterTodosPerfisQuery, IEnumerable<Perfil>>
    {
        private readonly IPerfilRepository _perfilRepository;

        public ObterTodosPerfisQueryHandler(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<IEnumerable<Perfil>> Handle(ObterTodosPerfisQuery request, CancellationToken cancellationToken)
        {
            return await _perfilRepository.ObterTodos();
        }
    }
}
