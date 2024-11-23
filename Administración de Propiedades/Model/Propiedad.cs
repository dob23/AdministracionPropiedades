using System.Collections.Generic;
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

        public ICollection<Inquilino> Inquilinos { get; set; } = new List<Inquilino>();
        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
