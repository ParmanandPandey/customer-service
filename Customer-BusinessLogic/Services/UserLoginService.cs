using AutoMapper;
using Customer.BusinessLogic.Contracts;
using Customer.Model.Models;
using Customer.Model.Requests;
using Customer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BusinessLogic.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper _mapper;

        public UserLoginService(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
        }


        public async Task<UserDataModel> GetUser(Guid userId)
        {
            var result = await this.userRepo.GetUser(userId);
            var userDto = this._mapper.Map<UserDataModel>(result);

            return userDto;
        }

        public async Task<bool> VerifyUser(UserLoginModel userLoginModel)
        {
            var result = await this.userRepo.GetUser(userLoginModel.EmailId, userLoginModel.Password);

            var userDto = this._mapper.Map<UserDataModel>(result);
            if (userDto != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
