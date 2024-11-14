using System.ComponentModel.DataAnnotations;

namespace Administración_de_Propiedades.Model
{
    public class Usuario
    {
        [Key] // Indica que este campo es la clave primaria
        public int Id { get; set; } // Id de usuario

        [Required] // Hace que el campo sea obligatorio
        [StringLength(50)] // Limita la longitud del nombre de usuario
        public string NombreUsuario { get; set; } // Nombre de usuario

        [Required] // Hace que el campo sea obligatorio
        [StringLength(100)] // Limita la longitud de la contraseña
        public string Contraseña { get; set; } // Contraseña del usuario
    }
}
