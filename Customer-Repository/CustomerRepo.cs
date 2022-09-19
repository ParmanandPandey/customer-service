using Customer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerDbContext _contaxt;
        public CustomerRepo(CustomerDbContext context)
        {
            _contaxt = context;
        }  

        public async Task<Entities.CustomerEntity> AddCustomer(CustomerEntity customerEntity)
        {
            customerEntity.CustomerId = Guid.NewGuid();
            var result = await _contaxt.Customers.AddAsync(customerEntity);
            await _contaxt.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            var isDeleted = false;
            var result = await _contaxt.Customers.Where(a => a.CustomerId == customerId).FirstOrDefaultAsync();
            if (result != null)
            {
                _contaxt.Customers.Remove(result);

                if (await _contaxt.SaveChangesAsync() > 0)
                {
                    isDeleted = true;
                }

            }

            return isDeleted;
        }

        public async Task<List<Entities.CustomerEntity>> GetAllCustomer()
        {
            return await _contaxt.Customers.ToListAsync();
        }

        public async Task<CustomerEntity> GetCustomer(Guid customerId)
        {
            return await _contaxt.Customers.FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }

        public async Task<bool> UpdateCustomer(Guid customerId, CustomerEntity customerEntity)
        {
            var result = await _contaxt.Customers.FirstOrDefaultAsync(a => a.CustomerId == customerId);
            if (result != null)
            {
                _contaxt.Customers.Update(customerEntity);
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

        public async Task<CustomerEntity> GetCustomer(string emailId, string password)
        {
            try
            {
                var result = await _contaxt.Customers
                               .SingleOrDefaultAsync(a => a.EmailId == emailId
                               && a.Password == password);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }
    }
}



