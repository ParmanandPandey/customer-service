using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Repository.Entities
{
    public interface IUserRepo
    {
        Task<List<UserEntity>> GetAllUser();


        Task<UserEntity> GetUser(Guid userId);


        Task<UserEntity> AddUser(UserEntity userEntity);


        Task<bool> UpdateUser(Guid userId, Entities.UserEntity userEntity);


        Task<bool> DeleteUser(Guid userId);


        Task<UserEntity> GetUser(string emailId, string password);

    }
}

