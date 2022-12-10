using Core.DataAccess.Abstract;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
