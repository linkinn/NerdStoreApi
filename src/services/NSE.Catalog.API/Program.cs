using NSE.Catalog.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfig()
    .AddDbContextConfig()
    .AddSwaggerConfig()
    .AddDependencyInjectionConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
