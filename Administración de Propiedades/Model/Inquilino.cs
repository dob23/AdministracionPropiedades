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
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }

        // Relación muchos a uno con Propiedad
        public int IdPropiedad { get; set; }
        [ForeignKey("IdPropiedad")]
        public Propiedad Propiedad { get; set; }

        // Relación uno a muchos con Contratos
        public ICollection<Contrato> Contratos { get; set; }
    }
}
