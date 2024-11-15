using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Propiedades
{
    public class CreateModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public CreateModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propiedad Propiedad { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Propiedades.Add(Propiedad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
