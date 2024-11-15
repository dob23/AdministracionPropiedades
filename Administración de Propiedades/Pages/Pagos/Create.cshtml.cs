using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Pagos
{
    public class CreateModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public CreateModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pago Pago { get; set; } = default!;

        public SelectList Contratos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Contratos = new SelectList(await _context.Contratos.ToListAsync(), "IdContrato", "IdContrato"); // Cambiar según el campo que desees mostrar

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Contratos = new SelectList(await _context.Contratos.ToListAsync(), "IdContrato", "IdContrato");
                return Page();
            }
            _context.Pagos.Add(Pago);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
