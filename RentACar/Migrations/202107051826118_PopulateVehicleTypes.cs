namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VehicleTypes (Id, Name, Description) VALUES (1, 'Cabrio', 'Cabrio')");
            Sql("INSERT INTO VehicleTypes (Id, Name, Description) VALUES (2, 'Jeeps Suvs', 'Jeeps Suvs')");
            Sql("INSERT INTO VehicleTypes (Id, Name, Description) VALUES (3, 'Luxury', 'Luxury')");
            Sql("INSERT INTO VehicleTypes (Id, Name, Description) VALUES (4, 'Small', 'Small')");
        }
        
        public override void Down()
        {
        }
    }
}
