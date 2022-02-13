using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechnicalTestApi.Data.Models
{
    public class Registration
    {
        [JsonIgnore]
        public string Id { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public string Locale { get; set; }

        [JsonIgnore]
        public string PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
        [JsonIgnore]
        public string OrganisationId { get; set; }
        [Required]
        public Organisation Organisation { get; set; }
    }
}
