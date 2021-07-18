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
        private readonly ILogger<ConnectorController> _logger;

        public ConnectorController(IConnector dataRepository, ILogger<ConnectorController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;

        }
        // GET: api/Connector
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Connector> connectors = await _dataRepository.Get();
            return Ok(connectors);
        }
        // GET: api/Connector/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Connector connector = await _dataRepository.GetById(id);
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
            await _dataRepository.Post(connector);
            return CreatedAtRoute(
                  "Get",
                  new { Id = connector.Id },
                  connector);
        }
        // PUT: api/Connector/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Connector connector)
        {
            if (connector == null)
            {
                return BadRequest("Connector is null.");
            }
            Connector connectorToUpdate = await _dataRepository.GetById(id);
            if (connectorToUpdate == null)
            {
                return NotFound("The connector record couldn't be found.");
            }
            await _dataRepository.Update(connector);//connectorToUpdate
            return NoContent();
        }
        // DELETE: api/Connector/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Connector connector= await _dataRepository.GetById(id);
            if (connector == null)
            {
                return NotFound("The connector record couldn't be found.");
            }
            await _dataRepository.Delete(connector);
            return NoContent();
        }

    }
}
