using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalTestApi.Models
{
    public class Registration
    {
        [Key]
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Locale { get; set; }

        [ForeignKey("AddressId")]
        public virtual Person Person { get; set; }
        [ForeignKey("OrganisationId")]
        public virtual Organisation Organisation { get; set; }
    }

    public class Address
    {
        [Key]
        public string AddressID { get; set; }
        public string Locale { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string CountryIsoCode { get; set; }
    }

    public class Person
    {
        [Key]
        public string PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }

    public class Organisation
    {
        [Key]
        public string OrganisationID { get; set; }
        public string Name { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
