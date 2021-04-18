using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IOperatorDataAccess
    {
        Task<Operator> InsertAsync(OperatorUpdateModel Operator);
        Task<IEnumerable<Operator>> GetAsync();
        Task<Operator> GetAsync(IOperatorIdentity OperatorId);
        Task<Operator> UpdateAsync(OperatorUpdateModel Operator);
    }
}