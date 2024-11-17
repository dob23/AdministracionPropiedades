using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Pagos
{
    public class DeleteModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public DeleteModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pago Pago { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pago = await _context.Pagos
                .Include(p => p.Contrato) 
                .FirstOrDefaultAsync(m => m.IdPago == id);

            if (Pago == null)
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

            Pago = await _context.Pagos.FindAsync(id);

            if (Pago != null)
            {
                _context.Pagos.Remove(Pago);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
