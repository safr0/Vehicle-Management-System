using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagement.DataAcess.VehicleDBContext;
using VehicleManagement.DataAcess.Entities;
using System.Linq;

namespace VehicleManagement.Domain.Services
{
    public class VehicleManagementService : IVehicleManagementService
    {

        private VehiclesDBContext _context;

        public VehicleManagementService(VehiclesDBContext context)
        {
            _context = context;            
        }
        
        public async Task<Car> AddCarAsync(Car car)
        {

            await _context.Cars.AddAsync(car);
            return car;
        }
        
        public async Task<Car> GetCarById(int carId)
        {
            return await _context.Cars.FindAsync(carId);
        }

        public List<Car> GetCars()
        {
            return _context.Cars.AsQueryable().ToList();
        }

        
        public async Task<bool> UpdateCarAsync(Car car)
        {
            var dbCar = _context.Cars.Find(car.ID);
            if(dbCar != null)
            {                
                dbCar.Title = car.Title;
                dbCar.Make = car.Make;
                dbCar.Model = car.Model;
                dbCar.Seats = car.Seats;
                dbCar.VinNumber = car.VinNumber;
                
                //dbCar.Specs = car.Specs;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

    }
}
