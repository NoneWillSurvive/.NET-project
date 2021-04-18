using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IOperatorUpdateService
    {
        Task<Operator> UpdateAsync(OperatorUpdateModel operators);
    }
}