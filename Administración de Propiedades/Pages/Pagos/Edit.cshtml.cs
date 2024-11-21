using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Administración_de_Propiedades.Data;

namespace Administración_de_Propiedades.Pages.Pagos
{
    public class EditModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public EditModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pago Pago { get; set; }

        public SelectList ContratoOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pago = await _context.Pagos.FindAsync(id);

            if (Pago == null)
            {
                return NotFound();
            }

            ContratoOptions = new SelectList(await _context.Contratos.ToListAsync(), "IdContrato", "IdContrato");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(Pago.IdPago))
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

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.IdPago == id);
        }
    }
}
