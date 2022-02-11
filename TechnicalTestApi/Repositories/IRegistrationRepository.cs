using TechnicalTestApi.Models;

namespace TechnicalTestApi.Repositories
{
    public interface IRegistrationRepository
    {
        Task<Registration> Get(string id);
        Task<Registration> Create(Registration registration);
    }
}
