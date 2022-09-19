using AutoMapper;
using Customer.BusinessLogic.Contracts;
using Customer.Model;
using Customer.Model.Requests;
using Customer.Model.Responses;
using Customer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Model.Base;
using Customer.Model.Models;

namespace Customer.BusinessLogic.Services
{
    public class UserService : IUserservice
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this._mapper = mapper;
        }
        public async Task<UserAddResponseModel> AddUser(UserAddRequestModel userRequest)
        {
            try
            {
                var UserDto = this._mapper.Map<UserEntity>(userRequest);

                var result = await this.userRepo.AddUser(UserDto);

                return new UserAddResponseModel()
                {
                    UserId = result.UserID,
                    Source = "User-AddUser"
                };
            }
            catch (Exception ex)
            {
                return new UserAddResponseModel()
                {
                    Source = "User-AddUser",
                    Response = new Model.Base.Response()
                    {
                        Code = UserErrorCode.AddUserErrorCode,
                        Description = $"{UserErrorCode.AddUserErrorDesc}, ErrorMessage: {ex.Message}"
                    }
                };
            }
        }

        public async Task<UserDeleteResponseModel> DeleteUser(Guid userId)
        {
            var result = await this.userRepo.DeleteUser(userId);

            return new UserDeleteResponseModel()
            {
                IsDeleted = result,
                Source = "UserService.DeleteUser"
            };
        }
        public async Task<List<UserDataModel>> GetAllUser()
        {
            var result = await this.userRepo.GetAllUser();
            var UserDto = this._mapper.Map<List<UserDataModel>>(result);

            return UserDto;
        }

        public async Task<UserDataModel> GetUser(Guid userId)
        {
            var result = await this.userRepo.GetUser(userId);
            var userDto = this._mapper.Map<UserDataModel>(result);

            return userDto;
        }
        public async Task<UserUpdateResponseModel> UpdateUser(Guid userId, UserUpdateRequestModel userUpdateRequest)
        {
            try
            {
                var userData = this._mapper.Map<UserEntity>(userUpdateRequest);

                var result = await this.userRepo.UpdateUser(userId, userData);

                return new UserUpdateResponseModel()
                {
                    Source = "UserService.UpdateUser",
                    Updated = result
                };
            }
            catch (Exception ex)
            {
                return new UserUpdateResponseModel()
                {
                    Source = "Customer-Services",
                    Response = new Model.Base.Response()
                    {
                        Code = UserErrorCode.UpdateUserErrorCode,
                        Description = $"{UserErrorCode.UpdateUserErrorDesc}, ErrorMessage: {ex.Message}"
                    },
                    Updated = false
                };
            }
        }
    }
}
