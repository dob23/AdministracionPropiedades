using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Administración_de_Propiedades.Pages.Contratos
{
    public class CreateModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public CreateModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contrato Contrato { get; set; } = default!;

        public SelectList Propiedades { get; set; } = default!;
        public SelectList Inquilinos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Propiedades = new SelectList(await _context.Propiedades.ToListAsync(), "IdPropiedad", "Direccion");
            Inquilinos = new SelectList(await _context.Inquilinos.ToListAsync(), "IdInquilino", "Nombre");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Propiedades = new SelectList(await _context.Propiedades.ToListAsync(), "IdPropiedad", "Direccion");
                Inquilinos = new SelectList(await _context.Inquilinos.ToListAsync(), "IdInquilino", "Nombre");
                return Page();
            }
            _context.Contratos.Add(Contrato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
