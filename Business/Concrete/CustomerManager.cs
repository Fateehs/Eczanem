using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerRepository _customerRepository;
        IOrderRepository _orderRepository;

        public CustomerManager(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerRepository.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(c => c.Id == id));
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(c => c.UserId == userId));
        }

        public IDataResult<Order> GetConfirmationNumber(string orderNumber)
        {
            return new SuccessDataResult<Order>(_orderRepository.Get(o => o.OrderNumber == orderNumber));
        }

        public IResult Add(Customer customer)
        {
            _customerRepository.Add(customer);

            return new SuccessResult();
        }

        public IResult Update(Customer customer)
        {
            _customerRepository.Update(customer);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var customer = _customerRepository.Get(c => c.Id == id);

            if (customer != null)

                _customerRepository.Delete(customer);

            return new SuccessResult();
        }
    }
}
