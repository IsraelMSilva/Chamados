﻿using Chamados.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Application.Querys.Perfis
{
    public class ObterTodosPerfisQuery : IRequest<IEnumerable<Perfil>>
    {
    }
}