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
    public class ObterUsuarioPorIdQueryHandler : IRequestHandler<ObterUsuarioPorIdQuery, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterUsuarioPorIdQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.ObterPorId(request.Id);
        }
    }
}
