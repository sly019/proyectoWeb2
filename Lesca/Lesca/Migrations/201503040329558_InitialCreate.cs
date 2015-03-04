namespace Lesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        solicitud = c.Int(nullable: false),
                        nombre = c.String(),
                        direccion = c.String(),
                        contacto = c.String(),
                        telefono = c.String(),
                        Enum = c.Byte(nullable: false),
                        cpe = c.String(),
                        volocidad = c.String(),
                        IP_publica = c.String(),
                        IP_Privada = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
