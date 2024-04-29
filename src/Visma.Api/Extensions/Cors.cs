namespace Visma.HR.Api.Extensions
{
    ///<inheritdoc/>
    public static class Cors
    {
        private static readonly string[] _origins = new string[1]
        {
            "http://localhost:4200"
        };

        private static readonly string[] _methods = new string[5]
        {
            "GET",
            "POST",
            "PUT",
            "PATCH",
            "DELETE"
        };

        ///<inheritdoc/>
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "corsPolicies",
                                  builder =>
                                  {
                                      builder.WithOrigins(_origins)
                                             .WithMethods(_methods)
                                             .AllowAnyHeader();
                                  });
            });
        }
    }
}
