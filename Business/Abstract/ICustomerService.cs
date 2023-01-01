using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<Customer> GetByUserId(int userId);
        IDataResult<Order> GetConfirmationNumber(string orderNumber);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(int id);
    }
}
