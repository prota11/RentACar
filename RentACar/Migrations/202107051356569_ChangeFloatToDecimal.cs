namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFloatToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VehicleGroups", "PricePerDay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleGroups", "PricePerDay", c => c.Single(nullable: false));
            AlterColumn("dbo.Bookings", "Price", c => c.Single(nullable: false));
        }
    }
}
