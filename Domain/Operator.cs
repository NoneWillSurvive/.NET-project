using Domain.Contracts;

namespace Domain
{
    public class Operator : IPhoneNumberContainer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CostForMonth { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        int? IPhoneNumberContainer.PhoneNumberId => this.PhoneNumber.Id;
    }
}