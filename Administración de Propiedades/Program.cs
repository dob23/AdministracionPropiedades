using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Administración_de_Propiedades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages(options =>
            {
               
                options.Conventions.AllowAnonymousToPage("/Autenticacion/Login");
                options.Conventions.AllowAnonymousToPage("/Autenticacion/Register");
            });
           
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                 
                    options.Cookie.Name = "MyCookieAuth";
                    options.LoginPath = "/Autenticacion/Login";
                });
           
            builder.Services.AddDbContext<PropiedadesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Propiedades"))
            );

            
            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
  
            app.UseAuthentication();
            app.UseAuthorization();
         
            app.MapRazorPages();

           
            app.Run();
        }
    }
}
