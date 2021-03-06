using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class GroupController : ControllerBase
    {
        private readonly IGroup _dataRepository;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroup dataRepository, ILogger<GroupController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;

        }

        // GET: api/Group
        [HttpGet]
        [ActionName(nameof(Get))]
        public async Task<ActionResult<List<Group>>> Get()
        {
            List<Group> groups = await _dataRepository.GetAsync();
            return Ok(groups);
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        [ActionName(nameof(Get))]
        public async Task<ActionResult<Group>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Group group = await _dataRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound("The group record couldn't be found.");
            }
            return Ok(group);
        }

        // POST: api/Group
        [HttpPost]
        [ActionName(nameof(Post))]
        public async Task<ActionResult<Group>> Post([FromBody] Group group)
        {
            if (group == null)
            {
                return BadRequest("Group is null.");
            }
            await _dataRepository.PostAsync(group);
            return CreatedAtAction(nameof(Get), new { id = group.Id }, group);
            
        }

        // PUT: api/Group/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Group group)
        {
            if (group == null)
            {
                return BadRequest("Groups is null.");
            }
            if (id != group.Id || id == 0)
            {
                return BadRequest();
            }
            Group groupToUpdate = await _dataRepository.GetByIdAsync(id);
            if (groupToUpdate == null)
            {
                return NotFound("The group record couldn't be found.");
            }

            try
            {
                 await _dataRepository.UpdateAsync(group);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dataRepository.Exists(group.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Group group = await _dataRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound("The group record couldn't be found.");
            }
            await _dataRepository.DeleteAsync(group);
            return NoContent();
        }
       
    }
}
