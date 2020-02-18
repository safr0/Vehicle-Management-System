using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagement.DataAcess.Entities;
using System.Linq;

namespace VehicleManagement.DataAcess.VehicleDBContext
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using var context = new VehiclesDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<VehiclesDBContext>>());
            
            if (context.Cars.Any())
            {
                return;   // Database has been seeded
            }

            context.Cars.AddRange(
                new Car
                {
                    ID = 1,
                    Title = "Audi 80",
                    Make = "Audi",
                    Model = "80",
                    Seats = 5,
                    VinNumber = "VIN1234567",
                   
                    Specs = new CarSpecification() { SpecificationId = 1, Doors = 4, BodyType = BodyType.Sedan , Engine="V8" },
                },
                new Car
                {
                    ID = 2,
                    Title = "Audi 90",
                    Make = "Audi",
                    Model = "90",
                    Seats = 5,
                    VinNumber = "VIN1234517",
                    Specs = new CarSpecification() { SpecificationId = 2, Doors = 4, BodyType = BodyType.Sedan, Engine = "V2" },
                },
                new Car
                {
                    ID = 3,
                    Title = "Audi A1",
                    Make = "Audi",
                    Model = "A1",
                    Seats = 5,
                    VinNumber = "VIN1234527",
                    Specs = new CarSpecification() { SpecificationId = 3, Doors = 4, BodyType = BodyType.Sedan, Engine = "2.2" },
                },
                new Car
                {
                    ID = 4,
                    Title = "BMW 1 Series",
                    Make = "BMW",
                    Model = "1 Series",
                    Seats = 5,
                    VinNumber = "VIN1234537",
                    Specs = new CarSpecification() { SpecificationId = 4, Doors = 4, BodyType = BodyType.SUV, Engine = "2.0" },
                },
                new Car
                {
                    ID = 5,
                    Title = "Holden Apollo",
                    Make = "Holden",
                    Model = "Apollo",
                    Seats = 5,
                    VinNumber = "VIN1234437",
                    Specs = new CarSpecification() { SpecificationId = 5, Doors = 4, BodyType = BodyType.HatchBack, Engine = "2.0" },
                },
                new Car
                {
                    ID = 6,
                    Title = "Holden Astra",
                    Make = "Holden",
                    Model = "Astra",
                    Seats = 5,
                    VinNumber = "VIN1234447",
                    Specs = new CarSpecification() { SpecificationId = 6, Doors = 4, BodyType = BodyType.HatchBack, Engine = "3.0" },
                });  

            context.SaveChanges();
        }
    }
}
