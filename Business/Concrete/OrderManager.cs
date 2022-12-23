using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
