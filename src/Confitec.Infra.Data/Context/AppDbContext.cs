using Confitec.Domain.Entities;
using Confitec.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Infra.Data.Context;

public class AppDbContext : DbContext
{
	public AppDbContext()
	{
	}

	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{
	}

	public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfiguration(new UsuarioConfig());

        base.OnModelCreating(modelBuilder);
    }
}


