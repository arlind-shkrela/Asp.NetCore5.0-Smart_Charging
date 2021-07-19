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
    public class ConnectorController : ControllerBase
    {
        private readonly IConnector _dataRepository;
        private readonly IChargeStation _changeStationdataRepository;
        private readonly ILogger<ConnectorController> _logger;

        public ConnectorController(IConnector dataRepository, IChargeStation changeStationdataRepository,
            ILogger<ConnectorController> logger)
        {
            _dataRepository = dataRepository;
            _changeStationdataRepository = changeStationdataRepository;
            _logger = logger;

        }
        // GET: api/Connector
        [HttpGet]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Connector> connectors = await _dataRepository.GetAsync();
            return Ok(connectors);
        }
        // GET: api/Connector/5
        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            Connector connector = await _dataRepository.GetByIdAsync(id);
            if (connector == null)
            {
                return NotFound("The connector record couldn't be found.");
            }
            return Ok(connector);
        }
        // POST: api/Connector
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Connector connector)
        {
            if (connector == null)
            {
                return BadRequest("Connector is null.");
            }
            //add to changeStation
            if (connector.ChargeStationsId != 0 || connector.ChargeStationsId != null)
            {
                
                //check capacity
                


               var connectorId =  await _dataRepository.PostAsync(connector);

                ChargeStation changeStation = await _changeStationdataRepository.GetByIdAsync(connector.ChargeStationsId ?? 0);
                if (changeStation != null)
                {
                    changeStation.ConnectorId = connectorId;
                    await _changeStationdataRepository.UpdateAsync(changeStation);
                }
                return CreatedAtAction(nameof(Get), new { id = connector.Id }, connector);
            }
            else
            {
                return BadRequest();
            }
         

        }
        // PUT: api/Connector/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Connector connector)
        {
            if (connector == null)
            {
                return BadRequest("Connector is null.");
            }
            Connector connectorToUpdate = await _dataRepository.GetByIdAsync(id);
            if (connectorToUpdate == null)
            {
                return NotFound("The connector record couldn't be found.");
            }
            await _dataRepository.UpdateAsync(connector);//connectorToUpdate
            return NoContent();
        }
        // DELETE: api/Connector/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Connector connector= await _dataRepository.GetByIdAsync(id);
            if (connector == null)
            {
                return NotFound("The connector record couldn't be found.");
            }
            await _dataRepository.DeleteAsync(connector);
            return NoContent();
        }

    }
}
