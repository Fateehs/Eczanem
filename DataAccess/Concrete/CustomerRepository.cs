using Core.DataAccess.Concrete;
using Core.Entities.Concrete.DTOs;
using Core.Entities.Concretes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
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
    }
}
