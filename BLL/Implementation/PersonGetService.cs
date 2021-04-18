using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class PersonGetService: IPersonGetService
    {
        private IPersonDataAccess PersonDataAccess { get; }
        
        public PersonGetService(IPersonDataAccess PersonDataAccess)
        {
            this.PersonDataAccess = PersonDataAccess;
        }

        public Task<IEnumerable<Person>> GetAsync()
        {
            return this.PersonDataAccess.GetAsync();
        }

        public Task<Person> GetAsync(IPersonIdentity Person)
        {
            return this.PersonDataAccess.GetAsync(Person);
        }
    }
}