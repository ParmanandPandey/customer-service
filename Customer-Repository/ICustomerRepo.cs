using Customer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Repository
{
    public interface ICustomerRepo
    {
       
        Task<List<CustomerEntity>> GetAllCustomer();
        
        Task<CustomerEntity> GetCustomer(Guid customerId);
        
        Task<CustomerEntity> AddCustomer(Entities.CustomerEntity customerEntity);
        
        Task<bool> UpdateCustomer(Guid customerId, Entities.CustomerEntity customerEntity);
        
        Task<bool> DeleteCustomer(Guid customerId);

        Task<CustomerEntity> GetCustomer(string emailId, string password);

    }
}
