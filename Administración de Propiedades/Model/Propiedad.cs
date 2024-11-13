using System.ComponentModel.DataAnnotations;

namespace Administración_de_Propiedades.Model
{
    public class Propiedad
    {
        [Key]
        public int IdPropiedad { get; set; }

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; }

        [Required]
        public string TipoPropiedad { get; set; }

        [Required]
        public int NumeroHabitaciones { get; set; }

        [Required]
        public decimal PrecioAlquiler { get; set; }

        [Required]
        public bool Disponible { get; set; } 

        // Relación uno a muchos con Inquilinos
        public ICollection<Inquilino> Inquilinos { get; set; }

        // Relación uno a muchos con Contratos
        public ICollection<Contrato> Contratos { get; set; }
    }
}
