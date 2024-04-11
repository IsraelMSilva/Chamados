using Chamados.Application.Commands.Usuarios;
using Chamados.Domain.Entities;
using Chamados.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.CommandHandlers.Usuarios
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;

        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
        }

        public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var perfil = await _perfilRepository.ObterPorId(request.PerfilId);

            if (perfil == null)
                throw new Exception("O perfil especificado não foi encontrado.");

            var usuario = Usuario.AdicionarUsuario(request.Nome, request.CPF, request.Email, request.PerfilId, request.Ativo);
            await _usuarioRepository.Adicionar(usuario);
            return usuario.Id;
        }
    }
}
