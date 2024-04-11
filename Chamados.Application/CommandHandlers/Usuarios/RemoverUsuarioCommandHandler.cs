using Chamados.Application.Commands.Usuarios;
using Chamados.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.CommandHandlers.Usuarios
{
    public class RemoverUsuarioCommandHandler : IRequestHandler<RemoverUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public RemoverUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.Id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            await _usuarioRepository.Remover(usuario);
            return Unit.Value;
        }
    }
}
