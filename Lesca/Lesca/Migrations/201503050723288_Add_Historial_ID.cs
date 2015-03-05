namespace Lesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Historial_ID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Historials", "NombreCliente", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Historials", "NombreCliente", c => c.Int(nullable: false));
        }
    }
}
