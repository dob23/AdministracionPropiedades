using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Inquilinos
{
    public class DeleteModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public DeleteModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inquilino Inquilino { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inquilino = await _context.Inquilinos
                .Include(i => i.Propiedad) 
                .FirstOrDefaultAsync(m => m.IdInquilino == id);

            if (Inquilino == null)
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

            Inquilino = await _context.Inquilinos.FindAsync(id);

            if (Inquilino != null)
            {
                _context.Inquilinos.Remove(Inquilino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
