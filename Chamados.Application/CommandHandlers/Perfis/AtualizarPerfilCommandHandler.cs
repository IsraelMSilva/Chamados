using Chamados.Application.Commands.Perfis;
using Chamados.Domain.Entities;
using Chamados.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.CommandHandlers.Perfis
{
    public class AtualizarPerfilCommandHandler : IRequestHandler<AtualizarPerfilCommand, Unit>
    {
        private readonly IPerfilRepository _perfilRepository;

        public AtualizarPerfilCommandHandler(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<Unit> Handle(AtualizarPerfilCommand request, CancellationToken cancellationToken)
        {
            var perfil = await _perfilRepository.ObterPorId(request.Id);

            if (perfil != null)
            {
                perfil.AtualizarPerfil(request.Descricao);
                await _perfilRepository.Atualizar(perfil);
            }
            else
                throw new Exception("Perfil não encontrado");

            return Unit.Value;
        }

    }
}
