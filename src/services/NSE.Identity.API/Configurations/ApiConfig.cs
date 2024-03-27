namespace NSE.Configuration
{
    public static class APiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            return builder;
        }
    }
}