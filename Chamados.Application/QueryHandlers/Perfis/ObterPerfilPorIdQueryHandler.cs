﻿using Chamados.Application.Commands.Perfis;
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
    public class ObterPerfilPorIdQueryHandler : IRequestHandler<ObterPerfilPorIdQuery, Perfil>
    {
        private readonly IPerfilRepository _perfilRepository;

        public ObterPerfilPorIdQueryHandler(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<Perfil> Handle(ObterPerfilPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _perfilRepository.ObterPorId(request.Id);
        }

    }
}