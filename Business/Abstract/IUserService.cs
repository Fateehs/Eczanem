using Core.Entities.Concrete;
using Core.Entities.Concretes;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEmail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int id);
        List<OperationClaim> GetClaims(User user);
    }
}
