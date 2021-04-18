using Domain.Contracts;

namespace Domain.Models
{
    public class PersonUpdateModel : IPersonIdentity, IPhoneNumberContainer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int? PhoneNumberId { get; set; }
    }
}