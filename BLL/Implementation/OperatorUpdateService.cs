using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class OperatorUpdateService : IOperatorUpdateService
    {
        private IOperatorDataAccess OperatorDataAccess { get; }
        private IPhoneNumberGetService PhoneNumberGetService { get; }
        
        public OperatorUpdateService(IOperatorDataAccess OperatorDataAccess, IPhoneNumberGetService PhoneNumberGetService)
        {
            this.OperatorDataAccess = OperatorDataAccess;
            this.PhoneNumberGetService = PhoneNumberGetService;
        }

        public async Task<Operator> UpdateAsync(OperatorUpdateModel Operator)
        {
            await this.PhoneNumberGetService.ValidateAsync(Operator);

            return await this.OperatorDataAccess.UpdateAsync(Operator);
        }
    }
}