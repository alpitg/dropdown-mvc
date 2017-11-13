namespace MvcCRUD1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
        }
    }
}
