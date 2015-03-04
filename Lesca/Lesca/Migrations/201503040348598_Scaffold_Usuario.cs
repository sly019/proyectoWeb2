namespace Lesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Scaffold_Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        userEmail = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 15),
                        Enum = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
