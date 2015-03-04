namespace Lesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Para_Password_Encripted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "password", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Usuarios", "PasswordSalt", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "PasswordSalt", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Usuarios", "password", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
