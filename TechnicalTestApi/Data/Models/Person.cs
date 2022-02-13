using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechnicalTestApi.Data.Models
{
    public class Person
    {
        [JsonIgnore]
        public string PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
        [JsonIgnore]
        public string AddressId { get; set; }
        public Address Address { get; set; }        
    }
}
