using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smart_ChargingApi.Interfaces;
using Smart_ChargingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargeStationController : ControllerBase
    {
        private readonly IChargeStation _dataRepository;
        private readonly ILogger<ChargeStationController> _logger;
        public ChargeStationController(IChargeStation dataRepository, ILogger<ChargeStationController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }
        // GET: api/ChargeStation
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ChargeStation> chargeStations = await _dataRepository.Get();
            return Ok(chargeStations);
        }
        // GET: api/ChargeStation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ChargeStation chargeStation = await _dataRepository.GetById(id);
            if (chargeStation == null)
            {
                return NotFound("The Charge Station record couldn't be found.");
            }
            return Ok(chargeStation);
        }
        // POST: api/ChargeStation
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChargeStation chargeStation)
        {
            if (chargeStation == null)
            {
                return BadRequest("Charge Station is null.");
            }
            await _dataRepository.Post(chargeStation);
            return CreatedAtRoute(
                  "Get",
                  new { Id = chargeStation.Id },
                  chargeStation);
        }
        // PUT: api/ChargeStation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ChargeStation chargeStation)
        {
            if (chargeStation == null)
            {
                return BadRequest("Charge Station is null.");
            }
            ChargeStation chargeStationToUpdate = await _dataRepository.GetById(id);
            if (chargeStationToUpdate == null)
            {
                return NotFound("The Charge Station record couldn't be found.");
            }
            await _dataRepository.Update(chargeStationToUpdate); //chargeStationToUpdate
            return NoContent();
        }
        // DELETE: api/ChargeStation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ChargeStation chargeStation = await _dataRepository.GetById(id);
            if (chargeStation == null)
            {
                return NotFound("The Charge Station record couldn't be found.");
            }
            await _dataRepository.Delete(chargeStation);
            return NoContent();
        }
    }
}
