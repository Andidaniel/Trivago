namespace Trivago.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        RoomId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Floor = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        Status = c.String(),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.RoomServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        RoomId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.RoomServices", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomImages", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Prices", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomImages", "ImageId", "dbo.Images");
            DropIndex("dbo.RoomServices", new[] { "ServiceId" });
            DropIndex("dbo.RoomServices", new[] { "RoomId" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Prices", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.RoomImages", new[] { "ImageId" });
            DropIndex("dbo.RoomImages", new[] { "RoomId" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Services");
            DropTable("dbo.RoomServices");
            DropTable("dbo.Reservations");
            DropTable("dbo.Prices");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomImages");
            DropTable("dbo.Images");
        }
    }
}
