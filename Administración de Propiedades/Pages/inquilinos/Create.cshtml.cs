using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Administración_de_Propiedades.Data;
using Administración_de_Propiedades.Model;
using System.Threading.Tasks;

namespace Administración_de_Propiedades.Pages.Inquilinos
{
    public class CreateModel : PageModel
    {
        private readonly PropiedadesContext _context;

        public CreateModel(PropiedadesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inquilino Inquilino { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inquilinos.Add(Inquilino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
