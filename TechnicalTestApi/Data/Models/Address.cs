using System.Text.Json.Serialization;

namespace TechnicalTestApi.Data.Models
{
    public class Address
    {
        [JsonIgnore]
        public string AddressId { get; set; }
        public string Locale { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string CountryIsoCode { get; set; }
    }
}
