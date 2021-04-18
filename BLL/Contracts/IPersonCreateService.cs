using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IPersonCreateService
    {
        Task<Person> CreateAsync(PersonUpdateModel person);
    }
}