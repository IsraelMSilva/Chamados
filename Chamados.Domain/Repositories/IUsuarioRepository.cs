using Chamados.Domain.Entities;
using Chamados.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Domain.Repositories
{
    public interface IUsuarioRepository : IRepositoryCrud<Usuario>
    {
    }
}
