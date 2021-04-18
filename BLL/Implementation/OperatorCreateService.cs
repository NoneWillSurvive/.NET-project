using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class OperatorCreateService : IOperatorCreateService
    {
        private IOperatorDataAccess OperatorDataAccess { get; }
        private IPhoneNumberGetService PhoneNumberGetService { get; }
        
        public OperatorCreateService(IOperatorDataAccess OperatorDataAccess, IPhoneNumberGetService PhoneNumberGetService)
        {
            this.OperatorDataAccess = OperatorDataAccess;
            this.PhoneNumberGetService = PhoneNumberGetService;
        }

        public async Task<Operator> CreateAsync(OperatorUpdateModel Operator)
        {
            await this.PhoneNumberGetService.ValidateAsync(Operator);
            
            return await this.OperatorDataAccess.InsertAsync(Operator);
        }
    }
}