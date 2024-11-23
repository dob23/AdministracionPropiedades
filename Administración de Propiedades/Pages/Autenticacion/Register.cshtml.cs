using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Autenticacion
{
    public class RegisterModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public RegisterModel(PropiedadesContext context)
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
                .FirstOrDefaultAsync(u => u.NombreUsuario == Usuario.NombreUsuario);

            if (usuarioExistente != null)
            {
                ModelState.AddModelError("Error", "El nombre de usuario ya está en uso.");
                return Page();
            }

           
            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            
            return RedirectToPage("/Autenticacion/Login");
        }
    }
}
