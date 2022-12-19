using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            services.AddScoped<ICourierRepository, CourierRepository>();

            return services;
        }
    }
}
