using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Propiedades
{
    public class IndexModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public IndexModel(PropiedadesContext context)
        {
            _context = context;
        }

        public IList<Propiedad> Propiedades { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Propiedades != null)
            {
                Propiedades = await _context.Propiedades.ToListAsync();
            }
        }
    }
}
