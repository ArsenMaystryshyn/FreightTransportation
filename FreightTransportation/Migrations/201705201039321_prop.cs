namespace FreightTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prop : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            AlterColumn("dbo.Orders", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Orders", "OrderId");
        }
    }
}
