using AutoMapper;
using Customer.BusinessLogic.Contracts;
using Customer.Model;
using Customer.Model.Models;
using Customer.Model.Requests;
using Customer.Model.Responses;
using Customer.Repository;
using Customer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
            this.customerRepo = customerRepo;
            this._mapper = mapper;
        }

        public async Task<CustomerAddResponseModel> AddCustomer(CustomerAddRequestModel customerRequest)
        {
            try
            {
                var customerDto = this._mapper.Map<CustomerEntity>(customerRequest);

                var result = await this.customerRepo.AddCustomer(customerDto);

                return new CustomerAddResponseModel()
                {
                    CustomerId = result.CustomerId,
                    Source = "Customer-AddCustomer"
                };
            }
            catch (Exception ex)
            {
                return new CustomerAddResponseModel()
                {
                    Source = "Customer-AddCustomer",
                    Response = new Model.Base.Response()
                    {
                        Code = ErrorCode.AddUserErrorCode,
                        Description = $"{ErrorCode.AddCutomerErrorDesc}, ErrorMessage: {ex.Message}"
                    }
                };
            }
        }

        public async Task<CustomerDeleteResponseModel> DeleteCustomer(Guid customerId)
        {
            var result = await this.customerRepo.DeleteCustomer(customerId);

            return new CustomerDeleteResponseModel()
            {
                IsDeleted = result,
                Source = "CustomerService.DeleteCustomer"
            };
        }

        public async Task<List<CustomerDataModel>> GetAllCustomer()
        {
            var result = await this.customerRepo.GetAllCustomer();
            var customerDto = this._mapper.Map<List<CustomerDataModel>>(result);

            return customerDto;
        }

        public async Task<CustomerDataModel> GetCustomer(Guid customerId)
        {
            var result = await this.customerRepo.GetCustomer(customerId);
            var customerDto = this._mapper.Map<CustomerDataModel>(result);

            return customerDto;
        }

        public async Task<CustomerUpdateResponseModel> UpdateCustomer(Guid customerId, CustomerUpdateRequestModel customerRequest)
        {
            try
            {
                var customerData = this._mapper.Map<CustomerEntity>(customerRequest);

                var result = await this.customerRepo.UpdateCustomer(customerId, customerData);

                return new CustomerUpdateResponseModel()
                {
                    Source = "CustomerService.UpdateCustomer",
                    Updated = result
                };
            }
            catch (Exception ex)
            {
                return new CustomerUpdateResponseModel()
                {
                    Source = "Customer-Services",
                    Response = new Model.Base.Response()
                    {
                        Code = ErrorCode.UpdateCutomerErrorCode,
                        Description = $"{ErrorCode.UpdateCutomerErrorDesc}, ErrorMessage: {ex.Message}"
                    },
                    Updated = false
                };
            }
        }
    }
}
