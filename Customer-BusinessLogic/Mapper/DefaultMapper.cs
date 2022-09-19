using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Customer.Model.Models;
using Customer.Model.Requests;
using Customer.Repository.Entities;

namespace Customer.BusinessLogic.Mapper
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<CustomerDataModel, CustomerEntity>().ReverseMap();
            CreateMap<CustomerAddRequestModel, CustomerEntity>().ReverseMap();
            CreateMap<UserUpdateRequestModel, CustomerEntity>().ReverseMap();

            CreateMap<CustomerEntity, CustomerLoginModel>()
                .ForMember(o => o.EmailId, b => b.MapFrom(z => z.EmailId))
                .ForMember(o => o.Password, b => b.MapFrom(z => z.Password))
                .ReverseMap();
            CreateMap<UserDataModel, UserEntity>().ReverseMap();
            CreateMap<UserAddRequestModel, UserEntity>().ReverseMap();
            CreateMap<UserUpdateRequestModel, UserEntity>().ReverseMap();

            CreateMap<UserEntity, UserLoginModel>()
                .ForMember(o => o.EmailId, b => b.MapFrom(z => z.EmailId))
                .ForMember(o => o.Password, b => b.MapFrom(z => z.Password))
                .ReverseMap();
        }
    }
}
