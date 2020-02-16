using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagement.DataAcess.Entities;

namespace VehicleManagement.Domain.Services
{
    public interface IVehicleManagementService
    {        
        Task<Car> GetCarById(int carId);
        List<Car> GetCars();
        Task<Car> AddCarAsync(Car car);
        Task DeleteCar(Car car);
    }
}
