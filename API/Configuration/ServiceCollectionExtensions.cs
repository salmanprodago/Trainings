using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            //services.AddDbContext<>
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.AddSecurityDefinition(name: "Bearer",
                    securityScheme: new OpenApiSecurityScheme()
                    {
                        Description = "Copy this into the value field: Bearer {token}",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT"
                    });

                config.AddSecurityRequirement(securityRequirement: new OpenApiSecurityRequirement()
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

                config.SwaggerDoc(name: "v1", info: new OpenApiInfo()
                {
                    Contact = new OpenApiContact()
                    {
                        Email = "salman.taj@infaque-prodago.com",
                        Name = "Infaque Business Solutions",
                        Url = new Uri(uriString: "https://infaque.com/")
                    },
                    Description = "Reclaim your right to be a philanthropist.",
                    License = new OpenApiLicense()
                    {
                        Name = "Infaque Business Solutions",
                        Url = new Uri(uriString: "https://infaque.com/about/")
                    },
                    Title = "API",
                    TermsOfService = new Uri(uriString: "https://infaque.com/about/"),
                    Version = "v1"
                });

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });

            return services;
        }
    }
}
