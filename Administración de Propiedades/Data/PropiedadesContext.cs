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
        public DbSet<Usuario> Usuarios { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Propiedad)
                .WithMany(p => p.Contratos)
                .HasForeignKey(c => c.IdPropiedad)  
                .OnDelete(DeleteBehavior.Restrict);  

           
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Inquilino)
                .WithMany(i => i.Contratos)
                .HasForeignKey(c => c.IdInquilino)  
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
