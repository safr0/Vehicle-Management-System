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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<VehicleManagementController> _logger;

        private readonly IVehicleManagementService _vehicleService;


        public VehicleManagementController(ILogger<VehicleManagementController> logger,IVehicleManagementService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<VehicleManagementVM>> Get()
        //{

        //    var tep = await _vehicleService.GetCarById(2);

        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new VehicleManagementVM
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPut("{id}")]
        public async Task<bool> PutVehicle(int id, VehicleManagementModel car)
        {
           await  _vehicleService.UpdateCarAsync(new Car() {Title= car.Title, ID = car.ID, Make = car.Make, Model = car.Model, Seats = car.Seats, VinNumber = car.VinNumber });
            return true;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleManagementModel>> GetVehicles()
        {
            var carList = _vehicleService.GetCars();         

            return carList.Select(car => new VehicleManagement.VehicleManagementModel
            {
                ID = car.ID,
                Title = car.Title,
                Make = car.Make,
                Model = car.Model,
                //Engine = ((CarSpecification)car.Specs).Engine,
                Seats = car.Seats,
                VinNumber = car.VinNumber,
                //SpecificationId =car.Specs.SpecificationId,
                //Doors = ((CarSpecification)car.Specs).Doors,
                //BodyType = (int)((CarSpecification)car.Specs).BodyType
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public async Task<ActionResult<VehicleManagementModel>> GetVehicle(int id)
        {
            var _car = _vehicleService.GetCarById(id);

            if (_car == null)
            {
                return NotFound();             
            }

            //return _car;
            return CreatedAtAction("GetVehicle", _car);

        }

    }
}
