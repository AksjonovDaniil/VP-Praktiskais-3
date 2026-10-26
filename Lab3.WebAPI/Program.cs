using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

namespace Lab3.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Именно эти настройки использует OpenAPI
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.NumberHandling =
                    JsonNumberHandling.Strict;
            });

            // Настройки JSON для Controllers
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.NumberHandling =
                        JsonNumberHandling.Strict;
                });

            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        "/openapi/v1.json",
                        "OpenAPI V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}