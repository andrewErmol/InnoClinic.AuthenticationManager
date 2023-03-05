using AuthenticationManager.BLL.IServices;
using AuthenticationManager.BLL.Services;
using AuthenticationManager.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthenticationManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(optionss =>
            {
                optionss.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer()
                .AddTestUsers(IdentityServerConfiguration.GetUsers())
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(opt =>
                {
                    opt.ConfigureDbContext = c => c.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                        sql => sql.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(opt =>
                {
                    opt.ConfigureDbContext = o => o.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                        sql => sql.MigrationsAssembly(migrationAssembly));
                });

            services.AddControllersWithViews();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationManagerDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                b.MigrationsAssembly("AuthenticationManager.DAL")));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<RoleManager<IdentityRole>>();
        }
    }
}