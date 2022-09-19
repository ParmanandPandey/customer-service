using Customer.Model.Models;
using Customer.Model.Requests;
using Customer.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BusinessLogic.Contracts
{
   public interface IUserservice
    {

        Task<List<UserDataModel>> GetAllUser();

        Task<UserDataModel> GetUser(Guid userId);

        Task<UserAddResponseModel> AddUser(UserAddRequestModel userAddRequest);

        Task<UserUpdateResponseModel> UpdateUser(Guid UserId, UserUpdateRequestModel userUpdateRequest);

        Task<UserDeleteResponseModel> DeleteUser(Guid UserId);
    }
}
