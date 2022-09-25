namespace API.Extensions;

public static class AddOriginsExtensions
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors( options => 
        {
            options.AddPolicy("CorsPolicy",
            policy => {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    // .WithOrigins("http://localhost:4200", "https://localhost:4200")
                    .AllowAnyOrigin();
            });
        });

        return services;
    }

    public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
    {
        app.UseCors("CorsPolicy");
        return app;
    }
}
