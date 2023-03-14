namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDecimalToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleGroups", "PricePerDay", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleGroups", "PricePerDay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
