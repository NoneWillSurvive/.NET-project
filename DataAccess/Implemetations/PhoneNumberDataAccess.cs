using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implemetations
{
    public class PhoneNumberDataAccess : IPhoneNumberDataAccess
    {
        private OperatorDirectoryContext Operator { get; }
        private IMapper Mapper { get; }
        
        public PhoneNumberDataAccess(OperatorDirectoryContext context, IMapper mapper)
        {
            this.Operator = context;
            this.Mapper = mapper;
        }

        public async Task<PhoneNumber> GetByAsync(IPhoneNumberContainer PhoneNumber)
        {
            return PhoneNumber.PhoneNumberId.HasValue 
                ? this.Mapper.Map<PhoneNumber>(await this.Operator.PhoneNumber.FirstOrDefaultAsync(x => x.Id == PhoneNumber.PhoneNumberId)) 
                : null;
        }
    }
}