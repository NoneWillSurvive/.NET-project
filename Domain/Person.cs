using Domain.Contracts;

namespace Domain
{
    public class Person: IPhoneNumberContainer
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public PhoneNumber PhoneNumber { get; set; }
        
        int? IPhoneNumberContainer.PhoneNumberId => this.PhoneNumber.Id;
    }
}