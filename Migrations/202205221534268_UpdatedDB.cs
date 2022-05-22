namespace Trivago.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        ExtraServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExtraServices", t => t.ExtraServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.ReservationId, cascadeDelete: true)
                .Index(t => t.ReservationId)
                .Index(t => t.ExtraServiceId);
            
            CreateTable(
                "dbo.ExtraServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationServices", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.ReservationServices", "ExtraServiceId", "dbo.ExtraServices");
            DropIndex("dbo.ReservationServices", new[] { "ExtraServiceId" });
            DropIndex("dbo.ReservationServices", new[] { "ReservationId" });
            DropTable("dbo.ExtraServices");
            DropTable("dbo.ReservationServices");
        }
    }
}
