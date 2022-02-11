using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestApi.Models;
using TechnicalTestApi.Repositories;

namespace TechnicalTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public IRegistrationRepository _registrationRepository;
        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistrations(string id)
        {
            return await _registrationRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistrations([FromBody]Registration registration)
        {
            var newRegistration = await _registrationRepository.Create(registration);
            return CreatedAtAction(nameof(GetRegistrations), new { id = newRegistration.Id }, newRegistration.Id);
        }
    }
}
