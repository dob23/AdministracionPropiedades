using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Inquilinos
{
    public class IndexModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public IndexModel(PropiedadesContext context)
        {
            _context = context;
        }

        public IList<Inquilino> Inquilinos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inquilinos != null)
            {
                Inquilinos = await _context.Inquilinos
                    .Include(i => i.Propiedad)
                    .ToListAsync();
            }
        }
    }
}
