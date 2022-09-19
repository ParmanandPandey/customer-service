using Customer.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BusinessLogic.Contracts
{
    public interface IUserLoginService
    {
        Task<bool> VerifyUser(UserLoginModel userLogin);
    }
}
