using NSE.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfig()
    .AddDbContextConfig()
    .AddIdentityConfig()
    .AddSwaggerConfig();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NSE.Identity.API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
