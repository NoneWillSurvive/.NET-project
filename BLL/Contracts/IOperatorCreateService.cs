﻿using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IOperatorCreateService
    {
        Task<Operator> CreateAsync(OperatorUpdateModel operators);
    }
}