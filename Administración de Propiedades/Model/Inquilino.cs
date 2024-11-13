using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Administración_de_Propiedades.Model
{
    public class Inquilino
    {
        [Key]
        public int IdInquilino { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Relación muchos a uno con Propiedad
        public int IdPropiedad { get; set; }
        [ForeignKey("IdPropiedad")]
        public Propiedad Propiedad { get; set; }

        // Relación uno a muchos con Contratos
        public ICollection<Contrato> Contratos { get; set; }
    }
}
