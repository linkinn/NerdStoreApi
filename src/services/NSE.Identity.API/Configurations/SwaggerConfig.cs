namespace NSE.Configuration
{
    public static class SwaggerConfig
    {
        public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new() { Title = "NSE.Identity.API", Version = "v1" });
            });
            
            return builder;
        }
    }
}