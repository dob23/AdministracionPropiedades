using Microsoft.EntityFrameworkCore;
using Administración_de_Propiedades.Model;

namespace Administración_de_Propiedades.Data
{
    public class PropiedadesContext : DbContext
    {
        
        public PropiedadesContext(DbContextOptions<PropiedadesContext> options) : base(options)
        {
        }

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
    }
}
