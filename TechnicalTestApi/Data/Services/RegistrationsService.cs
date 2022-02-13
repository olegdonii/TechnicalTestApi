using TechnicalTestApi.Data.Models;
using TechnicalTestApi.Models;
using TechnicalTestApi.Repositories;

namespace TechnicalTestApi.Services
{
    public class RegistrationsService : IRegistrationRepository
    {
        private RegistrationContext _context;

        public RegistrationsService(RegistrationContext context)
        {
            _context =  context;
        }

        public async Task<Registration> Create(ResponseRegistration registration)
        {
            var _registration = new Registration()
            {
                Id = Guid.NewGuid().ToString(),
                Locale = registration.Locale,
                RegistrationDate = DateTime.Now,
                Organisation = new Organisation()
                {
                    OrganisationId = Guid.NewGuid().ToString(),
                    Name = registration.Organisation.Name,
                    Address = new Address()
                    {
                        AddressId = Guid.NewGuid().ToString(),
                        AddressLine1 = registration.Organisation.Address.AddressLine1,
                        AddressLine2 = registration.Organisation.Address.AddressLine2,
                        AddressLine3 = registration.Organisation.Address.AddressLine3,
                        City = registration.Organisation.Address.City,
                        CountryIsoCode = registration.Organisation.Address.CountryIsoCode,
                        Locale = registration.Organisation.Address.Locale,
                        Postcode = registration.Organisation.Address.Postcode,
                        State = registration.Organisation.Address.State
                    }
                },
                Person = new Person()
                {
                    PersonId = Guid.NewGuid().ToString(),
                    FirstName = registration.Person.FirstName,
                    LastName = registration.Person.LastName,
                    Address = new Address()
                    {
                        AddressId = Guid.NewGuid().ToString(),
                        AddressLine1 = registration.Organisation.Address.AddressLine1,
                        AddressLine2 = registration.Organisation.Address.AddressLine2,
                        AddressLine3 = registration.Organisation.Address.AddressLine3,
                        City = registration.Organisation.Address.City,
                        CountryIsoCode = registration.Organisation.Address.CountryIsoCode,
                        Locale = registration.Organisation.Address.Locale,
                        Postcode = registration.Organisation.Address.Postcode,
                        State = registration.Organisation.Address.State
                    },
                    Email = registration.Person.Email
                }
            };
            _context.Registrations.Add(_registration);
            await _context.SaveChangesAsync();

            return _registration;
        }

        public async Task<Registration> Get(string id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if(registration == null)
            {
                return null;
            }
            var organisation = await _context.Organisations.FindAsync(registration.OrganisationId);
            organisation.Address = await _context.Addresses.FindAsync(organisation.AddressId);
            var person = await _context.Persons.FindAsync(registration.PersonId);
            person.Address = await _context.Addresses.FindAsync(person.AddressId);
            registration.Person = person;
            registration.Organisation = organisation;
            return registration;
        }
    }
}
