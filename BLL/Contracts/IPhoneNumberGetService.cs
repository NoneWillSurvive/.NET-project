using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IPhoneNumberGetService
    {
        Task ValidateAsync(IPhoneNumberContainer phoneNumberContainer);
    }
}