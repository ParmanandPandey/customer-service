using Customer.Model.Models;
using Customer.Model.Requests;
using Customer.Model.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.BusinessLogic.Contracts
{
    public interface ILoginService
    {
        Task<bool> VerifyUser(CustomerLoginModel loginModel);
    }
}
