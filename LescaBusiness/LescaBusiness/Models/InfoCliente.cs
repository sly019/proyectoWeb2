using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LescaBusiness.Models
{
    public class InfoCliente
    {
        public int ID { get; set; }

        [Display(Name = "# de solicitud")]
        public Int32 solicitud { get; set; }
        
        [Display(Name = "Nombre Cliente")]
        public string nombreCliente { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Persona de Contacto")]
        public string contacto { get; set; }
        
        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = "Tipo de conexión")]
        public MyEnum Enum { get; set; }
        
        [Display(Name = "Velocidad contratada")]
        public string volocidadcontratada { get; set; }

        [Display(Name = "# de CPE")]
        public string cpe { get; set; }

    }

    public class InfoClienteDBContext : DbContext
    {
        public DbSet<InfoCliente> InfoCliente { get; set; }
    }
        
    public enum MyEnum : byte
    {
        [Display(Name = "ONU")]
        Onu,

        [Display(Name = "Convertidor de medios")]
        Convertidordemedios,
    }
   
}