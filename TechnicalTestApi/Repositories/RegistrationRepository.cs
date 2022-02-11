using TechnicalTestApi.Models;

namespace TechnicalTestApi.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly RegistrationContext _context;
        public RegistrationRepository(RegistrationContext context)
        {
            _context = context;
        }

        public async Task<Registration> Create(Registration registration)
        {
            registration.Id = Guid.NewGuid().ToString();
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return registration;
        }

        public async Task<Registration> Get(string id)
        {
            return await _context.Registrations.FindAsync(id);
        }
    }
}
