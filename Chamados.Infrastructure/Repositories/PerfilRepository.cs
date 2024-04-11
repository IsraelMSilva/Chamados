using Chamados.Domain.Entities;
using Chamados.Domain.Repositories;
using Chamados.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chamados.Infrastructure.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationDbContext _context;

        public PerfilRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Perfil entity)
        {
            _context.Perfis.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Perfil entity)
        {
            _context.Perfis.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Perfil> ObterPorId(Guid id)
        {
            return await _context.Perfis.FindAsync(id);
        }

        public async Task<IEnumerable<Perfil>> ObterTodos()
        {
            return await _context.Perfis.ToListAsync();
        }

        public async Task Remover(Perfil entity)
        {
            _context.Perfis.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
