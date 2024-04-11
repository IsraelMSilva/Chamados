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
    public class RemoverPerfilCommandHandler : IRequestHandler<RemoverPerfilCommand, Unit>
    {
        private readonly IPerfilRepository _perfilRepository;

        public RemoverPerfilCommandHandler(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<Unit> Handle(RemoverPerfilCommand request, CancellationToken cancellationToken)
        {
            var perfil = await _perfilRepository.ObterPorId(request.Id);
            if (perfil != null)
            {
                await _perfilRepository.Remover(perfil);
            }
            else
            {
                throw new Exception("Perfil não encontrado");
            }

            return await Task.FromResult(Unit.Value);
        }

    }

}
