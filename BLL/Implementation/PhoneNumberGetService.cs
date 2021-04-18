using System;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class PhoneNumberGetService: IPhoneNumberGetService
    {
        private IPhoneNumberDataAccess PhoneNumberDataAccess { get; }
        
        public PhoneNumberGetService(IPhoneNumberDataAccess phoneNumberDataAccess)
        {
            this.PhoneNumberDataAccess = PhoneNumberDataAccess;
        }

        public async Task ValidateAsync(IPhoneNumberContainer phoneNumberContainer)
        {
            if (phoneNumberContainer == null)
            {
                throw new ArgumentNullException(nameof(phoneNumberContainer));
            }
            
            var phoneNumber = await this.GetBy(phoneNumberContainer);

            if (phoneNumberContainer.PhoneNumberId.HasValue && phoneNumber == null)
            {
                throw new InvalidOperationException($"PhoneNumber not found by id {phoneNumberContainer.PhoneNumberId}");
            }
        }

        private async Task<PhoneNumber> GetBy(IPhoneNumberContainer phoneNumberContainer)
        {
            return await this.PhoneNumberDataAccess.GetByAsync(phoneNumberContainer);
        }
    }
}