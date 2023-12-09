using Confitec.Application;
using Confitec.Application.Interfaces.Services;
using Confitec.Domain;
using Confitec.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Infra.CrossCutting.IoC;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Infra - Data
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        // Application - Services
        services.AddScoped<IUsuarioService, UsuarioService>();
    }
}
