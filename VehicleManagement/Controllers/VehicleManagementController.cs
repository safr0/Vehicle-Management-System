using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public VehicleManagementController(ILogger<VehicleManagementController> logger, IVehicleManagementService vehicleService, IMapper mapper)
        {
            _logger = logger;
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PostVehicle(CarViewModel car)
        {
            try
            {
                var _car = _mapper.Map<Car>(car);
                await _vehicleService.AddCarAsync(_car);
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
        public async Task<ActionResult<bool>> PutVehicle(int id, CarViewModel car)
        {
            try
            {
                var _car = _mapper.Map<Car>(car);
                await _vehicleService.UpdateCarAsync(_car);                
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
        public async Task<ActionResult<IEnumerable<CarViewModel>>> Get()
        {
            try
            {
                var carList = _vehicleService.GetCars();
                var _carModelList = _mapper.Map<List<CarViewModel>>(carList);                

                return CreatedAtAction("Get", _carModelList);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, exception.Message);
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarViewModel>> Get(int id)
        {
            var _carModel = new CarViewModel();

            var car = await _vehicleService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            if (car != null)
            {                
                _carModel = _mapper.Map<CarViewModel>(car);
            }

            return CreatedAtAction("Get", _carModel);
        }
    }
}
