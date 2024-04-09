using NSE.WebAPI.Core.Idendity;

namespace NSE.Catalog.API.Configurations
{
    public static class IdendityConfig
    {
        public static WebApplicationBuilder AddIdendityConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddJwtConfig(builder.Configuration);

            return builder;
        }
    }
}