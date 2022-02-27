namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(),
                        Address = c.String(),
                        BusinessEmailId = c.String(),
                        BusinessPhoneNumber = c.String(),
                        CPFirstName = c.String(),
                        CPLastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductLineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalProductPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ProductLines", t => t.ProductLineId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductLineId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ProductLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        PhotoUrl = c.String(),
                        QuantityInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderXStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.QuotationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuotationId = c.Int(nullable: false),
                        ProductLineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalProductPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductLines", t => t.ProductLineId, cascadeDelete: true)
                .ForeignKey("dbo.Quotations", t => t.QuotationId, cascadeDelete: true)
                .Index(t => t.QuotationId)
                .Index(t => t.ProductLineId);
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfRequest = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        OrderCreated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailId = c.String(),
                        PhoneNumber = c.String(),
                        EmergencyContactNumber = c.String(),
                        HomeAddress = c.String(),
                        WorkAddress = c.String(),
                        StaffTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffTypes", t => t.StaffTypeId, cascadeDelete: true)
                .Index(t => t.StaffTypeId);
            
            CreateTable(
                "dbo.StaffTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "StaffTypeId", "dbo.StaffTypes");
            DropForeignKey("dbo.QuotationDetails", "QuotationId", "dbo.Quotations");
            DropForeignKey("dbo.Quotations", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.QuotationDetails", "ProductLineId", "dbo.ProductLines");
            DropForeignKey("dbo.OrderXStatus", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderXStatus", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductLineId", "dbo.ProductLines");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.Staffs", new[] { "StaffTypeId" });
            DropIndex("dbo.Quotations", new[] { "ClientId" });
            DropIndex("dbo.QuotationDetails", new[] { "ProductLineId" });
            DropIndex("dbo.QuotationDetails", new[] { "QuotationId" });
            DropIndex("dbo.OrderXStatus", new[] { "OrderStatusId" });
            DropIndex("dbo.OrderXStatus", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductLineId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.StaffTypes");
            DropTable("dbo.Staffs");
            DropTable("dbo.Quotations");
            DropTable("dbo.QuotationDetails");
            DropTable("dbo.OrderXStatus");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.ProductLines");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Clients");
        }
    }
}
