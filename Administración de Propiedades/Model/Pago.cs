using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Administración_de_Propiedades.Model
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }

        // Relación muchos a uno con Contrato
        public int IdContrato { get; set; }
        [ForeignKey("IdContrato")]
        public Contrato Contrato { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public string Estado { get; set; }
    }
}
