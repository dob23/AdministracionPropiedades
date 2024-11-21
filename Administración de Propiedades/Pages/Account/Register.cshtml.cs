using Administración_de_Propiedades.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        private readonly PropiedadesContext _dbContext;

        public RegisterModel(PropiedadesContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            
            var existingUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == Usuario.NombreUsuario);
            if (existingUsuario != null)
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario ya está en uso.");
                return Page();
            }

          
            using (var sha256 = SHA256.Create())
            {
                Usuario.Contraseña = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(Usuario.Contraseña)));
            }

            
            _dbContext.Usuarios.Add(Usuario);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Index"); 
        }
    }
}
