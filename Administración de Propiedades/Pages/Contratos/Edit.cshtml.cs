using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Administración_de_Propiedades.Data;

namespace Administración_de_Propiedades.Pages.Contratos
{
    public class EditModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public EditModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contrato Contrato { get; set; }

        public SelectList PropiedadOptions { get; set; }
        public SelectList InquilinoOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contrato = await _context.Contratos
                .Include(c => c.Propiedad)
                .Include(c => c.Inquilino)
                .FirstOrDefaultAsync(m => m.IdContrato == id);

            if (Contrato == null)
            {
                return NotFound();
            }

            PropiedadOptions = new SelectList(await _context.Propiedades.ToListAsync(), "IdPropiedad", "Direccion");
            InquilinoOptions = new SelectList(await _context.Inquilinos.ToListAsync(), "IdInquilino", "Nombre");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(Contrato.IdContrato))
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

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.IdContrato == id);
        }
    }
}
