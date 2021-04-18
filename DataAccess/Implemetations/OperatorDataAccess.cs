using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implemetations
{
    public class OperatorDataAccess : IOperatorDataAccess
    {
        private OperatorDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public OperatorDataAccess(OperatorDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Operator> InsertAsync(OperatorUpdateModel Operator)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Operator>(Operator));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Operator>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Operator>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Operator>>(
                await this.Context.Operator.Include(x => x.PhoneNumber).ToListAsync());
        }

        public async Task<Domain.Operator> GetAsync(IOperatorIdentity Operator)
        {
            var result = await this.Get(Operator);

            return this.Mapper.Map<Domain.Operator>(result);
        }

        private async Task<Operator> Get(IOperatorIdentity Operator)
        {
            if (Operator == null)
            {
                throw new ArgumentNullException(nameof(Operator));
            }
            
            return await this.Context.Operator.Include(x => x.PhoneNumber)
                .FirstOrDefaultAsync(x => x.Id == Operator.Id);
        }

        public async Task<Domain.Operator> UpdateAsync(OperatorUpdateModel Operator)
        {
            var existing = await this.Get(Operator);

            var result = this.Mapper.Map(Operator, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Operator>(result);
        }
    }
}