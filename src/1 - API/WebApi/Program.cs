using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Host.UseSerilog
    (
         (hostingContext, loggerConfiguration) =>
         {
             loggerConfiguration.Enrich.FromLogContext()
                 .ReadFrom.Configuration(hostingContext.Configuration);
         }, false, writeToProviders: true
    );

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddScopedSwagger();
builder.Services.AddHealthCheckConfig();

var app = builder.Build();

// Configuração para rodar o Swagger APENAS no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicArchitecture API v1");
        c.RoutePrefix = "swagger"; // Mantém o Swagger acessível via /swagger
    });
}


app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHealthCheckConfig();
app.MapControllers();

app.Run();


