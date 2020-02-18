using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleManagement.DataAcess.Entities;
using VehicleManagement.Domain.Services;

namespace VehicleManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleManagementController : ControllerBase
    {
        private readonly ILogger<VehicleManagementController> _logger;

        private readonly IVehicleManagementService _vehicleService;

        public VehicleManagementController(ILogger<VehicleManagementController> logger, IVehicleManagementService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PostVehicle(VehicleManagementModel car)
        {
            try
            {
                await _vehicleService.AddCarAsync(new Car()
                {
                    Title = car.Title,
                    Make = car.Make,
                    Model = car.Model,
                    Seats = car.Seats,
                    VinNumber = car.VinNumber,

                    Specs = new CarSpecification()
                    {
                        Doors = car.Doors,
                        BodyType = (BodyType)car.BodyType,
                        Engine = car.Engine,
                    }
                });
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, exception.Message);
                return BadRequest();
            }
            return true;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PutVehicle(int id, VehicleManagementModel car)
        {
            try
            {
                await _vehicleService.UpdateCarAsync(new Car()
                {
                    Title = car.Title,
                    ID = car.ID,
                    Make = car.Make,
                    Model = car.Model,
                    Seats = car.Seats,
                    VinNumber = car.VinNumber,

                    Specs = new CarSpecification()
                    {
                        Doors = car.Doors,
                        BodyType = (BodyType)car.BodyType,
                        Engine = car.Engine,
                    }
                });
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, exception.Message);
                return BadRequest();
            }
            return true;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VehicleManagementModel>>> GetVehicles()
        {
            try
            {
                var carList = _vehicleService.GetCars();

                var carModels = carList.Select(car => new VehicleManagement.VehicleManagementModel
                {
                    ID = car.ID,
                    Title = car.Title,
                    Make = car.Make,
                    Model = car.Model,
                    Seats = car.Seats,
                    VinNumber = car.VinNumber,

                    SpecificationId = car.Specs.SpecificationId,
                    Engine = car.Specs.Engine,
                    Doors = car.Specs.Doors,
                    BodyType = (int)car.Specs.BodyType
                }).ToArray();

                return CreatedAtAction("GetVehicles", carModels);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, exception.Message);
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VehicleManagementModel>> GetVehicle(int id)
        {
            var _carModel = new VehicleManagementModel();

            var car = await _vehicleService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            if (car != null)
            {
                _carModel.ID = car.ID;
                _carModel.Title = car.Title;
                _carModel.Make = car.Make;
                _carModel.Model = car.Model;
                _carModel.Seats = car.Seats;
                _carModel.VinNumber = car.VinNumber;

                if (car.Specs != null)
                {
                    _carModel.SpecificationId = car.Specs.SpecificationId;
                    _carModel.Engine = car.Specs.Engine;
                    _carModel.Doors = car.Specs.Doors;
                    _carModel.BodyType = (int)car.Specs.BodyType;
                }
            }

            return CreatedAtAction("GetVehicle", _carModel);
        }
    }
}
