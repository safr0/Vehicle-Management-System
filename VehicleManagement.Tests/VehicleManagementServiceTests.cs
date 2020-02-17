using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VehicleManagement.DataAcess.Entities;
using VehicleManagement.DataAcess.VehicleDBContext;
using VehicleManagement.Domain.Services;
using Xunit;

namespace VehicleManagement.Tests
{
    public class VehicleManagementServiceTests
    {
        [Fact]
        public async void AddCarAsync_to_database()
        {
            var options = new DbContextOptionsBuilder<VehiclesDBContext>()
                .UseInMemoryDatabase(databaseName: "AddCarAsync_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new VehiclesDBContext(options))
            {
                var _vehicleService = new VehicleManagementService(context);
                var _car = new Car()
                {
                    ID = 1,
                    Title = "Audi 80",
                    Make = "Audi",
                    Model = "80",
                    Seats = 5,
                    VinNumber = "VIN1234567",
                    Specs = new CarSpecification() { SpecificationId = 1, Doors = 4, BodyType = BodyType.Sedan },
                };

                await _vehicleService.AddCarAsync(_car);
                context.SaveChanges();

                Assert.Equal(1, await context.Cars.CountAsync());
            }
        }

        [Fact]
        public async void GetCarById_from_database()
        {
            var options = new DbContextOptionsBuilder<VehiclesDBContext>()
                .UseInMemoryDatabase(databaseName: "GetCarById_from_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new VehiclesDBContext(options))
            {
                var _vehicleService = new VehicleManagementService(context);
                var _car = new Car()
                {
                    ID = 1,
                    Title = "Audi 80",
                    Make = "Audi",
                    Model = "80",
                    Seats = 5,
                    VinNumber = "VIN1234567",
                    Specs = new CarSpecification() { SpecificationId = 1, Doors = 4, BodyType = BodyType.Sedan },
                };

                await _vehicleService.AddCarAsync(_car);
                context.SaveChanges();
            }

            //later separate instance of the context to verify correct data was saved to database
            using (var context = new VehiclesDBContext(options))
            {
                var _vehicleService = new VehicleManagementService(context);
                var _car = await _vehicleService.GetCarById(1);

                Assert.Equal(1, _car.ID);
                Assert.Equal(1, await context.Cars.CountAsync());
            }
        }


        [Fact]
        public async void UpdateCarAync_database()
        {
            var options = new DbContextOptionsBuilder<VehiclesDBContext>()
                .UseInMemoryDatabase(databaseName: "UpdateCarAync_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = new VehiclesDBContext(options))
            {
                var _vehicleService = new VehicleManagementService(context);
                var _cars = new List<Car>() { new Car
                                                {
                                                    ID = 1,
                                                    Title = "Audi 80",
                                                    Make = "Audi",
                                                    Model = "80",
                                                    Seats = 5,
                                                    VinNumber = "VIN1234567",
                                                    Specs = new CarSpecification() { SpecificationId = 1, Doors = 4, BodyType = BodyType.Sedan },
                                                },
                                                new Car
                                                {
                                                    ID = 2,
                                                    Title = "Audi 90",
                                                    Make = "Audi",
                                                    Model = "90",
                                                    Seats = 5,
                                                    VinNumber = "VIN1234517",
                                                    Specs = new CarSpecification() { SpecificationId = 2, Doors = 4, BodyType = BodyType.Sedan },
                                                }
                                            };

                await _vehicleService.AddCarAsync(_cars[0]);
                await _vehicleService.AddCarAsync(_cars[1]);

                var _car = await _vehicleService.GetCarById(2);

                _car.Make = String.Empty;

                var isUpdated = await _vehicleService.UpdateCarAsync(_car);
                context.SaveChanges();
            }

            //later separate instance of the context to verify correct data was saved to database
            using (var context = new VehiclesDBContext(options))
            {
                var _vehicleService = new VehicleManagementService(context);
                var _car = await _vehicleService.GetCarById(2);
                Assert.Equal(2, _car.ID);
                Assert.Equal(String.Empty, _car.Make);
            }
        }

    }
}
