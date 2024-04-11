using Chamados.Domain.Entities;
using Chamados.Domain.Repositories;
using Chamados.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _context.Usuarios.Include(c => c.Perfil).FirstAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.Include(a => a.Perfil).ToListAsync();
        }

        public async Task Remover(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
