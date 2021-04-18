using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class PersonCreateService: IPersonCreateService
    {
        private IPersonDataAccess PersonDataAccess { get; }
        private IPhoneNumberGetService PhoneNumberGetService { get; }
        
        public PersonCreateService(IPersonDataAccess PersonDataAccess, IPhoneNumberGetService phoneNumberGetService)
        {
            this.PersonDataAccess = PersonDataAccess;
            this.PhoneNumberGetService = phoneNumberGetService;
        }

        public async Task<Person> CreateAsync(PersonUpdateModel Person)
        {
            await this.PhoneNumberGetService.ValidateAsync(Person);
            
            return await this.PersonDataAccess.InsertAsync(Person);
        }
    }
}