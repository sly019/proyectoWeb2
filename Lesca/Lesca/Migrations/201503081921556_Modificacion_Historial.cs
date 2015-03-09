namespace Lesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacion_Historial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Historials", "NombreCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Historials", "NombreCliente", c => c.String());
        }
    }
}
