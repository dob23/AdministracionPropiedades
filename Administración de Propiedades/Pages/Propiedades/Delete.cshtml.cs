using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Propiedades
{
    public class DeleteModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public DeleteModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propiedad Propiedad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Propiedad = await _context.Propiedades.FindAsync(id);

            if (Propiedad == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Propiedad = await _context.Propiedades.FindAsync(id);

            if (Propiedad != null)
            {
                _context.Propiedades.Remove(Propiedad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
