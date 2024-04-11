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
    public class CriarPerfilCommandHandler : IRequestHandler<CriarPerfilCommand, Guid>
    {
        private readonly IPerfilRepository _perfilRepository;

        public CriarPerfilCommandHandler(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<Guid> Handle(CriarPerfilCommand request, CancellationToken cancellationToken)
        {
            var perfil = Perfil.AdicionarPerfil(request.Descricao);
            await _perfilRepository.Adicionar(perfil);
            return await Task.FromResult(perfil.Id);
        }
    }
}
