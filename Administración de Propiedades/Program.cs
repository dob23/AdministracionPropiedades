using Administración_de_Propiedades.Data;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura el DbContext para usar la cadena de conexión 'Propiedades' desde appsettings.json
            builder.Services.AddDbContext<PropiedadesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Propiedades")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
