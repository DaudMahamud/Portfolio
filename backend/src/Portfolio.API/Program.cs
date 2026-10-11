using Portfolio.Infrastructure;
using Microsoft.OpenApi;

namespace Portfolio.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("De ConnectionString is niet gevonden."));
            
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Portfolio API",
                    Version = "v1"
                });
            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options =>
                {
                    options.RouteTemplate = "api/{documentName}/specifications.json";
                });

                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "api";
                    options.SwaggerEndpoint("v1/specifications.json", "Portfolio API");
                });

                app.MapGet("/", context =>
                {
                    context.Response.Redirect("/api");
                    return Task.CompletedTask;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
