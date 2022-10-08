﻿using ApplicationsServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void  AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            //MigrationsAssembly: Configura el ensamblado donde se mantienen las migraciones para este contexto.
            //El operador typeof obtiene la instancia System.Type para un tipo.
            //Ej:   int edad;
            //      Console.WriteLine((typeof(edad));
            // La salida por pantalla sera: System.Int32.
            //Assembly: Obtiene la propiedad Assembly en la que está declarado el tipo.
            //FullName: Obtiene el nombre para mostrar del ensamblado.
            services.AddDbContext<InstituteAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSqlServer"), c =>c.MigrationsAssembly(typeof(InstituteAppContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(RepositoryCustom<>));
            #endregion
        }
    }
}
