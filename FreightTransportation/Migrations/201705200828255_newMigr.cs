namespace FreightTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Price", c => c.Int(nullable: false));
        }
    }
}
