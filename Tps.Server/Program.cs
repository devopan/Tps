using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tps.Server.Data;

namespace Tps.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AllowedAppOrigins = "AllowedAppOrigins";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedAppOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:4200").WithHeaders("Content-Type").WithMethods("GET", "PUT", "POST", "DELETE");
                                  });
            });

            builder.Services.AddDbContext<TpmDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => {
                // set this option to TRUE to indent the JSON output
                options.JsonSerializerOptions.WriteIndented = true;
                // set this option to NULL to use PascalCase instead of
                // camelCase (default)
                // options.JsonSerializerOptions.PropertyNamingPolicy =
                // null;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(AllowedAppOrigins);
            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            CreateDbIfNotExists(app);

            app.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TpmDbContext>();
                    DatabaseInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

    }
}
