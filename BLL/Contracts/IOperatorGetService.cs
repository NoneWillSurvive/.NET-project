using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IOperatorGetService
    {
        Task<IEnumerable<Operator>> GetAsync();
        Task<Operator> GetAsync(IOperatorIdentity operators);
    }
}