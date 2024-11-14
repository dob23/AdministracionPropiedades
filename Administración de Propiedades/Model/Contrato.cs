using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Administración_de_Propiedades.Model
{
    public class Contrato
    {
        [Key]
        public int IdContrato { get; set; }

        // Relación muchos a uno con Propiedad
        public int IdPropiedad { get; set; }
        [ForeignKey("IdPropiedad")]
        public Propiedad Propiedad { get; set; }

        // Relación muchos a uno con Inquilino
        public int IdInquilino { get; set; }
        [ForeignKey("IdInquilino")]
        public Inquilino Inquilino { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Deposito { get; set; }

        [Required]
        public string Terminos { get; set; }

        // Relación uno a muchos con Pagos
        public ICollection<Pago> Pagos { get; set; }
    }
}
