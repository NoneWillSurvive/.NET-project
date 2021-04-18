using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IPersonDataAccess
    {
        Task<Person> InsertAsync(PersonUpdateModel Person);
        Task<IEnumerable<Person>> GetAsync();
        Task<Person> GetAsync(IPersonIdentity PersonId);
        Task<Person> UpdateAsync(PersonUpdateModel Person);
    }
}