using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IPersonUpdateService
    {
        Task<Person> UpdateAsync(PersonUpdateModel person);
    }
}