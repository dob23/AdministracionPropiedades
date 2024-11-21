using Administración_de_Propiedades.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        private readonly PropiedadesContext _dbContext;

        public LoginModel(PropiedadesContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

         
            var storedUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == Usuario.NombreUsuario);
            if (storedUsuario == null)
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                return Page();
            }

            using (var sha256 = SHA256.Create())
            {
                var passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(Usuario.Contraseña));

               
                if (!passwordHash.SequenceEqual(Encoding.UTF8.GetBytes(storedUsuario.Contraseña)))
                {
                    ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                    return Page();
                }
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, storedUsuario.NombreUsuario),
               
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            return RedirectToPage("/Index");
        }
    }
}
