using AutoMapper;
using Domain.Customer;
using Domain.Security;
using Service.Bo;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewOne.Configuration
{
    public class Automapper:Profile
    {

        public Automapper() {

            CreateMap<CustomerBo, Customer>().ReverseMap();
            CreateMap<LoginBo, User>().ReverseMap();
            CreateMap<LoginViewModel, LoginBo>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerBo>().ReverseMap();
        }


    }
}
