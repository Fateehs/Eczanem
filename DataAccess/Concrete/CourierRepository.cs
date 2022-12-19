using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CourierRepository : EntityRepositoryBase<Courier, BaseDbContext>, ICourierRepository
    {
        public CourierRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
