using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IPharmacyService, PharmacyManager>();
            services.AddScoped<ICourierService, CourierManager>();
            services.AddScoped<IMedicineService, MedicineManager>();
            services.AddScoped<IOrderService, OrderManager>();

            return services;
        }
    }
}
