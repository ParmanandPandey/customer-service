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
    public class LoginService : ILoginService
    {
        private readonly ICustomerRepo customerRepo;
        private readonly IMapper _mapper;

        public LoginService(ICustomerRepo customerRepo, IMapper mapper)
        {
            this.customerRepo = customerRepo;
            this._mapper = mapper;
        }


        public async Task<CustomerDataModel> GetCustomer(Guid customerId)
        {
            var result = await this.customerRepo.GetCustomer(customerId);
            var customerDto = this._mapper.Map<CustomerDataModel>(result);

            return customerDto;
        }

        public async Task<bool> VerifyUser(CustomerLoginModel loginModel)
        {
            var result = await this.customerRepo.GetCustomer(loginModel.EmailId, loginModel.Password);
            
            var customerDto = this._mapper.Map<CustomerDataModel>(result);
            if (customerDto != null)
            {
              return  true;
            }
            else
            {
                return false;
            }
        }
    }
}
