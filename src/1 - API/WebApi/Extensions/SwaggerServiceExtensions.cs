using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace WebApi.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddScopedSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BasicArchitecture API",
                    Version = "v1",
                    Description = "API para demonstrar a arquitetura básica com Clean Architecture.",
                    Contact = new OpenApiContact
                    {
                        Name = "Daiane Izidoro Antunes",
                        Email = "daiane.iantunes@gmail.com",
                        Url = new Uri("https://github.com/daianeiantunes")
                    }
                });

                // Suporte para autenticação via Bearer Token (caso sua API tenha autenticação)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT assim: Bearer {seu_token}",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseScopedSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicArchitecture API v1");
                c.RoutePrefix = string.Empty; // Acessível diretamente em http://localhost:5000/
            });

            return app;
        }
    }

}
