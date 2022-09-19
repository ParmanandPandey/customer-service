using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Repository.Entities
{
    public class UserRepo : IUserRepo
    {
        private readonly CustomerDbContext _contaxt;
        public UserRepo(CustomerDbContext context)
        {
            _contaxt = context;
        }

        public async Task<Entities.UserEntity> AddUser(UserEntity userEntity)
        {
            userEntity.UserID = Guid.NewGuid();
            var result = await _contaxt.Users.AddAsync(userEntity);
            await _contaxt.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var isDeleted = false;
            var result = await _contaxt.Users.Where(a => a.UserID == userId).FirstOrDefaultAsync();
            if (result != null)
            {
                _contaxt.Users.Remove(result);

                if (await _contaxt.SaveChangesAsync() > 0)
                {
                    isDeleted = true;
                }

            }

            return isDeleted;
        }

        public async Task<List<Entities.UserEntity>> GetAllUser()
        {
            return await _contaxt.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUser(Guid userId)
        {
            return await _contaxt.Users.FirstOrDefaultAsync(a => a.UserID == userId);
        }

        public async Task<bool> UpdateUser(Guid userId, UserEntity userEntity)
        {
            var result = await _contaxt.Users.FirstOrDefaultAsync(a => a.UserID == userId);
            if (result != null)
            {
                _contaxt.Users.Update(userEntity);
                if (await _contaxt.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<UserEntity> GetUser(string emailId, string password)
        {
            var result = await _contaxt.Users
                .SingleOrDefaultAsync(a => a.EmailId == emailId
                && a.Password == password);
            return result;

        }
    }
}
