namespace RentACar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (1, 'A1', 'A1', 15)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (2, 'B1', 'B1', 18)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (3, 'C', 'C', 20)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (4, 'C1', 'C1', 22)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (5, 'C2', 'C2', 25)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (6, 'C3', 'C3', 25)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (7, 'D', 'D', 25)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (8, 'D2', 'D2', 30)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (9, 'E', 'E', 35)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (10, 'E2', 'E2', 55)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (11, 'E3', 'E3', 55)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (12, 'G', 'G', 25)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (13, 'G1', 'G1', 31)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (14, 'G2', 'G2', 37)");
            Sql("INSERT INTO VehicleGroups (Id, Name, Description, PricePerDay) VALUES (15, 'G3', 'G3', 42)");
        }
        
        public override void Down()
        {
        }
    }
}
