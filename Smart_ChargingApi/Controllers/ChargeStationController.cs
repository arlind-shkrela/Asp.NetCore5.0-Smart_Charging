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
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ChargeStation> chargeStations = await _dataRepository.GetAsync();
            return Ok(chargeStations);
        }
        // GET: api/ChargeStation/5
        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            ChargeStation chargeStation = await _dataRepository.GetByIdAsync(id);
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
            List<ChargeStation> ChargeStationByGroup = await _dataRepository.GetChargeStationByGroupIdAsync(chargeStation.GroupId);
            if (ChargeStationByGroup.Count > 0)
            {
                return BadRequest("The Charge Station can be only in one Group at the same time!");
            }

            await _dataRepository.PostAsync(chargeStation);
            return CreatedAtAction(nameof(Get), new { id = chargeStation.Id }, chargeStation);

        }
        // PUT: api/ChargeStation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ChargeStation chargeStation)
        {
            if (chargeStation == null)
            {
                return BadRequest("Charge Station is null.");
            }
            ChargeStation chargeStationToUpdate = await _dataRepository.GetByIdAsync(id);
            if (chargeStationToUpdate == null)
            {
                return NotFound("The Charge Station record couldn't be found.");
            }
            await _dataRepository.UpdateAsync(chargeStationToUpdate); //chargeStationToUpdate
            return NoContent();
        }
        // DELETE: api/ChargeStation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ChargeStation chargeStation = await _dataRepository.GetByIdAsync(id);
            if (chargeStation == null)
            {
                return NotFound("The Charge Station record couldn't be found.");
            }
            await _dataRepository.DeleteAsync(chargeStation);
            return NoContent();
        }
    }
}
