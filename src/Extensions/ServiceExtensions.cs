using IdentityPasswordHasher.Data;
using IdentityPasswordHasher.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityPasswordHasher.Extensions
{
    public static class ServiceExtensions
    {
        public static void ProjectSettings(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add Identity services
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Setting up database
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("PwHashDB")
            );
            
            // Registering services
            services.AddScoped<IPasswordHashService, PasswordHashService>();
        }
    }
}
