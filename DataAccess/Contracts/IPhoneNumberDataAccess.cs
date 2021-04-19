using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace DataAccess.Contracts
{
    public interface IPhoneNumberDataAccess
    {
        Task<PhoneNumber> GetByAsync(IPhoneNumberContainer phoneNumberId);
    }
}