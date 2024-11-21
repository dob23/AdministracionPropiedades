using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Administración_de_Propiedades.Data;

namespace Administración_de_Propiedades.Pages.Inquilinos
{
    public class EditModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public EditModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inquilino Inquilino { get; set; }

        public SelectList PropiedadOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Inquilino = await _context.Inquilinos.Include(i => i.Propiedad)
                .FirstOrDefaultAsync(m => m.IdInquilino == id);

            if (Inquilino == null)
            {
                return NotFound();
            }

            PropiedadOptions = new SelectList(await _context.Propiedades.ToListAsync(), "IdPropiedad", "Direccion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inquilino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquilinoExists(Inquilino.IdInquilino))
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

        private bool InquilinoExists(int id)
        {
            return _context.Inquilinos.Any(e => e.IdInquilino == id);
        }
    }
}
