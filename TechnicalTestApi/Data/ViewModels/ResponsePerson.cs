namespace TechnicalTestApi.Data.ViewModels
{
    public class ResponsePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ResponseAddress Address { get; set; }
    }
}
