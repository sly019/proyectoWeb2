using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Lesca.Models
{
    public class Clientes
    {
        public int ID { get; set; }

        [Display(Name = "# de solicitud")]
        public Int32 solicitud { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string nombre { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Persona de Contacto")]
        public string contacto { get; set; }

        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = "Tipo de conexión")]
        public MyEnum Enum { get; set; }

        [Display(Name = "# de CPE")]
        public string cpe { get; set; }

        [Display(Name = "Velocidad contratada")]
        public string volocidad{ get; set; }
        
        [Display(Name = "Ip publica")]
        public string IP_publica { get; set; }

        [Display(Name = "Ip Privada")]
        public string IP_Privada { get; set; }
    }
    public enum MyEnum : byte
    {
        [Display(Name = "ONU")]
        Onu,

        [Display(Name = "Convertidor de medios")]
        Convertidor_de_medios,
    }
}