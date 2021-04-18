using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class PersonUpdateService : IPersonUpdateService
    {
        private IPersonDataAccess PersonDataAccess { get; }
        private IPhoneNumberGetService PhoneNumberGetService { get; }
        
        public PersonUpdateService(IPersonDataAccess PersonDataAccess, IPhoneNumberGetService PhoneNumberGetService)
        {
            this.PersonDataAccess = PersonDataAccess;
            this.PhoneNumberGetService = PhoneNumberGetService;
        }

        public async Task<Person> UpdateAsync(PersonUpdateModel Person)
        {
            await this.PhoneNumberGetService.ValidateAsync(Person);

            return await this.PersonDataAccess.UpdateAsync(Person);
        }
    }
}