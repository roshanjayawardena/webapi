using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewOne.Configuration
{
    public class ServiceInjector
    {

        public static void InjectServices(IServiceCollection services)
        {          
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
        }

    }
}
