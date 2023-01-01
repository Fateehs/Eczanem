using Core.DataAccess.Abstract;
using Core.Entities.Concrete.DTOs;
using Core.Entities.Concretes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
    }
}
