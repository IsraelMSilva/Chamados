using Chamados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamados.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>()
                .ToTable("Perfil")
                .HasKey(p => p.Id); 

            modelBuilder.Entity<Perfil>()
                .Property(p => p.Descricao)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Cpf)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Ativo)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
       .HasOne(u => u.Perfil)
       .WithMany() // Não especificamos a navegação inversa porque não temos a propriedade Perfil em Usuario
       .HasForeignKey(u => u.PerfilId)
       .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
