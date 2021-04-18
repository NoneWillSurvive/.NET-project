using Domain.Contracts;

namespace Domain.Models
{
    public class OperatorIdentityModel: IOperatorIdentity
    {
        public int Id { get; }

        public OperatorIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}