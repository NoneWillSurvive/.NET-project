using Domain.Contracts;

namespace Domain.Models
{
    public class PersonIdentityModel : IPersonIdentity
    {
        public int Id { get; }

        public PersonIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}