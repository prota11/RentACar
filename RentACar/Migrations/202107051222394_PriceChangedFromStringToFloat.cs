namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceChangedFromStringToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.VehicleGroups", "PricePerDay", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleGroups", "PricePerDay", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "Price", c => c.String(nullable: false));
        }
    }
}
