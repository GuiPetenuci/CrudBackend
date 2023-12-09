using Confitec.Domain;
using Confitec.Domain.Entities;
using Confitec.Infra.Data.Context;
using Confitec.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Infra.Data.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(IDbContextFactory<AppDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
}
