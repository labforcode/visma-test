using System.Reflection;
using System.Text.Json.Serialization;
using Visma.HR.Api.Extensions;
using Visma.HR.Api.Filters;

namespace Visma.HR.Api;

///<inheritdoc/>
public class Startup
{
    ///<inheritdoc/>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    ///<inheritdoc/>
    public IConfiguration Configuration { get; }

    ///<inheritdoc/>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddCorsConfiguration();
        services.AddJwtConfiguration();
        services.AddOpenApiConfiguration();
        services.AddNativeDependenceInjection(Configuration);
        services.AddMvc(options => options.Filters.Add<NotificationFilter>())
                .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }

    ///<inheritdoc/>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("corsPolicies");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UserSwaggerSetup();
    }
}

