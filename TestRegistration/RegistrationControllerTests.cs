using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using TechnicalTestApi.Controllers;
using TechnicalTestApi.Data.Models;
using TechnicalTestApi.Models;
using TechnicalTestApi.Services;
using Xunit;

namespace TestRegistration
{
    public class RegistrationControllerTests
    {
        private readonly Mock<RegistrationsService> repositoryStub = new();

        [Fact]
        public async Task GetRegistration_WithUnexistingRegistration_ReturnsNotFound()
        {
            repositoryStub.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((Registration)null);

            var controller = new RegistrationController(repositoryStub.Object);

            var result = await controller.GetRegistration(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetRegistration_WithExistingRegistration_ReturnsNotFound()
        {
            var expectedRegistration = CreateRandomRegistration();
            repositoryStub.Setup(x => x.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(expectedRegistration);

            var controller = new RegistrationController(repositoryStub.Object);

            var result = await controller.GetRegistration(Guid.NewGuid());

            Assert.IsType<Registration>(result.Value);
            var registration = result.Value;
            Assert.Equal(expectedRegistration.Id, registration?.Id);
        }

        [Fact]
        public async Task PostRegistrations_WithRegistrationToCreate_ReturnsRegistrationDate()
        {
            var registration = new ResponseRegistration
            {                
                Locale = Guid.NewGuid().ToString(),
                RegistrationDate = DateTime.Now
            };

            var controller = new RegistrationController(repositoryStub.Object);

            var result = await controller.PostRegistrations(registration);

            var createdRegistration = (result.Result as CreatedAtActionResult).Value as Registration;

            Assert.Equal(registration.RegistrationDate, createdRegistration.RegistrationDate);
        }


        private Registration CreateRandomRegistration()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Locale = "ru",
                RegistrationDate = DateTime.Now,
                Organisation = new Organisation()
                {
                    OrganisationId = Guid.NewGuid().ToString(),
                    Name = "Acme Ltd",
                    Address = new Address()
                    {
                        AddressId = Guid.NewGuid().ToString(),
                        AddressLine1 = "Gateway House",
                        AddressLine2 = "28 The Quadrant",
                        AddressLine3 = "",
                        City = "Richmond",
                        CountryIsoCode = "GBR",
                        Locale = "en",
                        Postcode = "TW9 1DN",
                        State = "Surrey"
                    }
                },
                Person = new Person()
                {
                    PersonId = Guid.NewGuid().ToString(),
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    Address = new Address()
                    {
                        AddressId = Guid.NewGuid().ToString(),
                        AddressLine1 = "Gateway House",
                        AddressLine2 = "28 The Quadrant",
                        AddressLine3 = "",
                        City = "Richmond",
                        CountryIsoCode = "GBR",
                        Locale = "en",
                        Postcode = "TW9 1DN",
                        State = "Surrey"
                    },
                    Email = "jjbloggs@mailinator.com"
                }
            };
        }
    }
}