using Core.DataAccess.Concrete;
using Core.Entities.Concrete.DTOs;
using Core.Entities.Concretes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CustomerRepository : EntityRepositoryBase<Customer, BaseDbContext>, ICustomerRepository
    {
        public CustomerRepository(BaseDbContext context) : base(context)
        {
        }

        public List<CustomerDTO> GetSyncCustomer(Expression<Func<Customer, bool>> filter = null)
        {
            var result = from customer in Context.Customers.Where(filter)
                         join user in Context.Users
                         on customer.UserId equals user.Id
                         where customer.UserId == user.Id
                         select new CustomerDTO
                         {
                             FirstName = user.FirstName,
                             MiddleName = user.MiddleName,
                             LastName = user.LastName,
                             Email = user.Email
                         };
            return result.ToList();
        }
    }
}
