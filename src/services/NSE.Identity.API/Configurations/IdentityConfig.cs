using Microsoft.AspNetCore.Identity;
using NSE.Identity.API.Data;
using NSE.WebAPI.Core.Idendity;

namespace NSE.Configuration
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            builder.Services.AddJwtConfig(builder.Configuration);

            return builder;
        }
    }
}