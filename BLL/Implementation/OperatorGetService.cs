using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class OperatorGetService : IOperatorGetService
    {
        private IOperatorDataAccess OperatorDataAccess { get; }
        
        public OperatorGetService(IOperatorDataAccess OperatorDataAccess)
        {
            this.OperatorDataAccess = OperatorDataAccess;
        }

        public Task<IEnumerable<Operator>> GetAsync()
        {
            return this.OperatorDataAccess.GetAsync();
        }

        public Task<Operator> GetAsync(IOperatorIdentity Operator)
        {
            return this.OperatorDataAccess.GetAsync(Operator);
        }
    }
}