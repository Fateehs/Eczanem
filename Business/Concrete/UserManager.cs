using Business.Abstract;
using Core.Entities.Concretes;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userRepository.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userRepository.Get(u => u.Id == id));
        }

        public IResult Add(User user)
        {
            _userRepository.Add(user);

            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userRepository.Update(user);

            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userRepository.Delete(user);

            return new SuccessResult();
        }
    }
}
