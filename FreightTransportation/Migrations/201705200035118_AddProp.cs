namespace FreightTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "CarModel", c => c.String());
            AddColumn("dbo.Drivers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "PhoneNumber");
            DropColumn("dbo.Drivers", "CarModel");
        }
    }
}
