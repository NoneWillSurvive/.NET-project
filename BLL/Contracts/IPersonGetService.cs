using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IPersonGetService
    {
        Task<IEnumerable<Person>> GetAsync();
        Task<Person> GetAsync(IPersonIdentity person);
    }
}