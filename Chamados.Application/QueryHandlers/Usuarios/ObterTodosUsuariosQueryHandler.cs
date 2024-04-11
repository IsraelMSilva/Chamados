using Chamados.Application.Querys.Usuarios;
using Chamados.Domain.Entities;
using Chamados.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.QueryHandlers.Usuarios
{
    public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, IEnumerable<Usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterTodosUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.ObterTodos();
        }
    }
}
