namespace Visma.Api;

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
        //services.AddCorsConfiguration();
        //services.AddAutoMapperConfiguration();
        //services.AddJwtConfiguration();
        //services.AddSwaggerConfiguration();
        //services.AddNativeDependenceInjection(Configuration);
        //services.AddMvc(options => options.Filters.Add<NotificationFilter>())
        //        .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);


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

        //app.UserSwaggerSetup();
    }
}

