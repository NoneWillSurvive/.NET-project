using Domain.Contracts;

namespace Domain.Models
{
    public class OperatorUpdateModel : IOperatorIdentity, IPhoneNumberContainer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CostForMonth { get; set; }

        public int? PhoneNumberId { get; set; }
    }
}