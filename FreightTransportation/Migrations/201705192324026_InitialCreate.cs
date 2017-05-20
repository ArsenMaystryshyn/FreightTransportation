namespace FreightTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        SendingCity = c.String(),
                        SendingDepartment = c.String(),
                        ReceivingCity = c.String(),
                        ReceivingDepartment = c.String(),
                        Status = c.String(),
                        CustomerUser_CustomerId = c.Int(),
                        DriverUser_DriverId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerUser_CustomerId)
                .ForeignKey("dbo.Drivers", t => t.DriverUser_DriverId)
                .Index(t => t.CustomerUser_CustomerId)
                .Index(t => t.DriverUser_DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DriverUser_DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "CustomerUser_CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "DriverUser_DriverId" });
            DropIndex("dbo.Orders", new[] { "CustomerUser_CustomerId" });
            DropTable("dbo.Drivers");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
