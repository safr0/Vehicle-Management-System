using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet]
        public async Task<IEnumerable<VehicleManagementVM>> Get()
        {

            var tep = await _vehicleService.GetCarById(2);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new VehicleManagementVM
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
