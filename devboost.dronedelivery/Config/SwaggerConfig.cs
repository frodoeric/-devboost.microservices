using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace devboost.dronedelivery.Config
{
    /// <summary>
    /// Classe que extende IServiceCollection e Configura o Swagger para API
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Adiciona Swagger Configuration, incluindo Authorize
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSwaggerconfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.CustomSchemaIds(x => x.FullName);
                opt.SwaggerDoc(configuration["SwaggerDoc:Version"], new OpenApiInfo
                {
                    Title = configuration["SwaggerDoc:Title"],
                    Version = configuration["SwaggerDoc:Version"],
                    Description = configuration["SwaggerDoc:Description"],
                    TermsOfService = new Uri(configuration["SwaggerDoc:TermsOfService"]),
                    Contact = new OpenApiContact
                    {
                        Name = configuration["SwaggerDoc:ContactName"],
                        Email = configuration["SwaggerDoc:ContactEMail"],
                        Url = new Uri(configuration["SwaggerDoc:ContactUrl"]),
                    }
                });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = configuration["SwaggerDoc:AuthorizeDescription"]
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //opt.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Adiciona path de onde o json Swagger deve ser gerado
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", configuration["SwaggerDoc:Version"]);
            });
        }
    }
}
