using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using Core.Entities.Concretes;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRepository : EntityRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var claims = from uoc in Context.UserOperationClaims
                         join oc in Context.OperationClaims
                         on uoc.OperationClaimId equals oc.Id
                         where uoc.UserId == user.Id
                         select new OperationClaim
                         { Id = oc.Id, Name = oc.Name };

            return claims.ToList();
        }
    }
}
