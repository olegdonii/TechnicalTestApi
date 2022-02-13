using TechnicalTestApi.Data.ViewModels;

namespace TechnicalTestApi.Models
{
    public class ResponseRegistration
    {
        public DateTime RegistrationDate { get; set; }
        public string Locale { get; set; }
        public ResponsePerson Person { get; set; }
        public ResponseOrganisation Organisation { get; set; }
    }
}
