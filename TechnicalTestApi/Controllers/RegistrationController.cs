using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using TechnicalTestApi.Data.Models;
using TechnicalTestApi.Models;
using TechnicalTestApi.Services;

namespace TechnicalTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public RegistrationsService _registrationService;
        public RegistrationController(RegistrationsService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(Guid id)
        {
            var registration = await _registrationService.GetById(id);
            if (registration is null)
            {
                return NotFound();
            }
            return registration;
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistrations([FromBody] ResponseRegistration registration)
        {
            if (ModelState.IsValid)
            {
                var newRegistration = await _registrationService.Create(registration);
                return CreatedAtAction(nameof(GetRegistration), new { id = newRegistration.Id },
                    new JsonObject
                    {
                        ["registrationId"] = newRegistration.Id
                    });
            } 
            else
            {
                return BadRequest();
            }
            
        }
    }
}
