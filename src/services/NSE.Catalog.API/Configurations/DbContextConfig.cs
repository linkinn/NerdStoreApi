using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Data;

namespace NSE.Configuration
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            return builder;
        }
    }
}