﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagement.DataAcess.VehicleDBContext;
using VehicleManagement.DataAcess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VehicleManagement.Domain.Services
{
    /// <summary>
    /// Vehicle service class to Save, Fetch and Modify vehicles 
    /// </summary>
    public class VehicleManagementService : IVehicleManagementService
    {
        private VehiclesDBContext _context;

        public VehicleManagementService(VehiclesDBContext context)
        {
            _context = context;            
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            if (car != null)
            {
                car.ID = _context.Cars.Any() ? _context.Cars.Select(x => x.ID).Max() + 1 : 1;

                if (car.Specs != null)
                {
                    car.Specs.SpecificationId = _context.Specs.Any() ? _context.Specs.Select(x => x.SpecificationId).Max() + 1 : 1;
                }

                await _context.Cars.AddAsync(car);
                _context.SaveChanges();
            }

            return car;
        }
        
        public async Task<Car> GetCarById(int carId)
        {            
            return await _context.Cars.Include(v => v.Specs).Where(x=>x.ID== carId).FirstOrDefaultAsync();
        }

        public List<Car> GetCars()
        {
            return _context.Cars.Include(v => v.Specs).AsQueryable().ToList();
        }

        
        public async Task<bool> UpdateCarAsync(Car car)
        {
            var dbCar = await _context.Cars.Include(v=>v.Specs).Where(v=>v.ID==car.ID).FirstOrDefaultAsync();
            
            if(dbCar != null)
            {                
                dbCar.Title = car.Title;
                dbCar.Make = car.Make;
                dbCar.Model = car.Model;
                dbCar.Seats = car.Seats;
                dbCar.VinNumber = car.VinNumber;

                if (car.Specs!=null)
                {
                    dbCar.Specs.Doors = car.Specs.Doors;
                    dbCar.Specs.Engine = car.Specs.Engine;
                    dbCar.Specs.BodyType = car.Specs.BodyType;
                }

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
