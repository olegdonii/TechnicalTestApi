using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechnicalTestApi.Data.Models
{
    public class Organisation
    {
        [JsonIgnore]
        public string OrganisationId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
