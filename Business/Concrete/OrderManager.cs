using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderRepository.GetAll());
        }

        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderRepository.Get(o => o.Id == id));
        }

        public IDataResult<Order> GetDetailsByNumber(string number)
        {
            return new SuccessDataResult<Order>(_orderRepository.Get(o => o.OrderNumber == number));
        }

        public IResult Add(Order order)
        {
            _orderRepository.Add(order);

            return new SuccessResult();
        }

        public IResult Update(Order order)
        {
            _orderRepository.Update(order);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var order = _orderRepository.Get(m => m.Id == id);

            if (order != null)

                _orderRepository.Delete(order);

            return new SuccessResult();
        }

        public string GenerateNumberWithLetters()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            int number = rnd.Next(100, 10000);

            sb.Append(number.ToString());

            char letter = (char)rnd.Next('A', 'Z' + 1);
            sb.Append(letter);

            return sb.ToString();
        }
    }
}
