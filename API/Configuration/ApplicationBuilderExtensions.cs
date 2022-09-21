using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger(config =>
            {
                config.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(config =>
            {
                //config.InjectStylesheet(path: "");
                config.DocumentTitle = "API";
                config.DocExpansion(DocExpansion.None);
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "v1");
            });

            return app;
        }
    }
}
