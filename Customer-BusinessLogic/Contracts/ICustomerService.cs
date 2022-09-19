using Customer.Model.Models;
using Customer.Model.Requests;
using Customer.Model.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.BusinessLogic.Contracts
{
    public interface ICustomerService
    {
        Task<List<CustomerDataModel>> GetAllCustomer();

        Task<CustomerDataModel> GetCustomer(Guid customerId);

        Task<CustomerAddResponseModel> AddCustomer(CustomerAddRequestModel customerRequest);

        Task<CustomerUpdateResponseModel> UpdateCustomer(Guid customerId, CustomerUpdateRequestModel customerRequest);

        Task<CustomerDeleteResponseModel> DeleteCustomer(Guid customerId);
    }
}
