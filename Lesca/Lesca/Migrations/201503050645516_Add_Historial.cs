namespace Lesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Historial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        NombreCliente = c.Int(nullable: false),
                        fecha = c.String(),
                        DescripFallo = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Historials");
        }
    }
}
