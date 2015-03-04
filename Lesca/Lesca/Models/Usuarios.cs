using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lesca.Models
{
    public class Usuarios
    {
        public int ID { get; set; }

       // public Guid IDUsuario { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string userEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(300, MinimumLength = 8)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Roll")]
        public MyEnumUsser Enum { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "passsalt")]
        public string PasswordSalt { get; set; }
    }

    public enum MyEnumUsser : byte
    {
        [Display(Name = "Administrador")]
        Administrador,

        [Display(Name = "Operador")]
        Operador,

        [Display(Name = "Visor")]
        Visor,
    }

}