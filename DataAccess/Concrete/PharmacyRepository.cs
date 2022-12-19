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
    public class PharmacyRepository : EntityRepositoryBase<Pharmacy, BaseDbContext>, IPharmacyRepository
    {
        public PharmacyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
