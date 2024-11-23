using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Autenticacion
{
    public class LoginModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public LoginModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            var usuarioExistente = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == Usuario.NombreUsuario && u.Contraseña == Usuario.Contraseña);

            if (usuarioExistente == null)
            {
                ModelState.AddModelError("Error", "Nombre de usuario o contraseña incorrectos.");
                return Page();
            }

           
            return RedirectToPage("/Index");
        }
    }
}
