using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Visma.HR.Api.Extensions
{
    ///<inheritdoc/>
    public static class OpenApi
    {
        ///<inheritdoc/>
        public static void AddOpenApiConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Visma Test API",
                    Description = "Provide resources to  Visma Test API.",
                    Contact = new OpenApiContact
                    {
                        Name = "Brito, Thiago",
                        Email = "labforcode@gmail.com"
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }

        ///<inheritdoc/>
        public static void UserSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visma.Api v1"));
        }
    }
}
