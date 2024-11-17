using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Contratos
{
    public class DeleteModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public DeleteModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contrato Contrato { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contrato = await _context.Contratos
                .Include(c => c.Propiedad)
                .Include(c => c.Inquilino)
                .FirstOrDefaultAsync(m => m.IdContrato == id);

            if (Contrato == null)
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

            Contrato = await _context.Contratos
                .Include(c => c.Pagos)
                .FirstOrDefaultAsync(m => m.IdContrato == id);

            if (Contrato != null)
            {
            
                _context.Pagos.RemoveRange(Contrato.Pagos);

               
                _context.Contratos.Remove(Contrato);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
