using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Domain.Services
{
    public interface IRepositoryCrud<T> where T : class
    {
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(T entity);
        Task<T> ObterPorId(Guid id);
        Task<IEnumerable<T>> ObterTodos();
    }
}
