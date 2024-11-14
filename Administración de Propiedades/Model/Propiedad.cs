using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Administración_de_Propiedades.Model
{
    public class Propiedad
    {
        [Key]
        public int IdPropiedad { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string TipoPropiedad { get; set; } 

        [Required]
        public int NumeroHabitaciones { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioAlquiler { get; set; }

        [Required]
        public bool Disponible { get; set; }

        // Relación uno a muchos con Inquilinos y Contratos
        public ICollection<Inquilino> Inquilinos { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    }
}
