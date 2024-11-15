using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Pagos
{
    public class IndexModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public IndexModel(PropiedadesContext context)
        {
            _context = context;
        }

        public IList<Pago> Pagos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pagos != null)
            {
                Pagos = await _context.Pagos
                    .Include(p => p.Contrato)
                    .ThenInclude(c => c.Propiedad)
                    .Include(p => p.Contrato)
                    .ThenInclude(c => c.Inquilino)
                    .ToListAsync();
            }
        }
    }
}
