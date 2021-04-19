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
    public class PersonDataAccess : IPersonDataAccess
    {
        private OperatorDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public PersonDataAccess(OperatorDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Person> InsertAsync(PersonUpdateModel Person)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Person>(Person));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Person>(result.Entity);
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Person>>(
                await this.Context.Person.Include(x => x.PhoneNumber).ToListAsync());
        }

        public async Task<Person> GetAsync(IPersonIdentity Person)
        {
            var result = await this.Get(Person);

            return this.Mapper.Map<Person>(result);
        }

        private async Task<Person> Get(IPersonIdentity Person)
        {
            if (Person == null)
            {
                throw new ArgumentNullException(nameof(Person));
            }
            
            return await this.Context.Person.Include(x => x.PhoneNumber)
                .FirstOrDefaultAsync(x => x.Id == Person.Id);
        }

        public async Task<Person> UpdateAsync(PersonUpdateModel Person)
        {
            var existing = await this.Get(Person);

            var result = this.Mapper.Map(Person, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Person>(result);
        }
    }
}