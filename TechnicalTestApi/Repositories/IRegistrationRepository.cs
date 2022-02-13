using TechnicalTestApi.Data.Models;
using TechnicalTestApi.Models;

namespace TechnicalTestApi.Repositories
{
    public interface IRegistrationRepository
    {
        Task<Registration?> GetById(Guid id);
        Task<Registration> Create(ResponseRegistration registration);
    }
}
