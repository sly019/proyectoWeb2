using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lesca.Models
{
    public class LescaDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LescaDbContext() : base("name=LescaDbContext")
        {
        }

        public System.Data.Entity.DbSet<Lesca.Models.Clientes> Clientes { get; set; }

        public System.Data.Entity.DbSet<Lesca.Models.Usuarios> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Lesca.Models.Historial> Historials { get; set; }


        internal Historial SqlQuery(string p)
        {
            throw new NotImplementedException();
        }
    }
}
