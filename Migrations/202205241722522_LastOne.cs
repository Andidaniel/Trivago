namespace Trivago.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExtraServices", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Deleted");
            DropColumn("dbo.ExtraServices", "Deleted");
        }
    }
}
