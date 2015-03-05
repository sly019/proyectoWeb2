using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesca.Models
{
    public class Historial
    {
        public int ID { get; set; }

        [Display(Name = "Id_Cliente")]
        public Int32 IdCliente{ get; set; }

        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "Fecha")]
        public string fecha { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Descripcion del fallo")]
        public string DescripFallo { get; set; }
    }
}