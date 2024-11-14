using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Model;
namespace Administración_de_Propiedades.Data
{
    public class PropiedadesContext : DbContext
    {
        public PropiedadesContext(DbContextOptions options) : base(options)
        {
        }

    }
}
