using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Model;
using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Data;
namespace Administración_de_Propiedades.Pages.Propiedades
{
    public class EditModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public EditModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propiedad Propiedad { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Propiedad = await _context.Propiedades.FindAsync(id);

            if (Propiedad == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Propiedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropiedadExists(Propiedad.IdPropiedad))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PropiedadExists(int id)
        {
            return _context.Propiedades.Any(e => e.IdPropiedad == id);
        }
    }
}
