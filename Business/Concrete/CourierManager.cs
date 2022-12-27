using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourierManager : ICourierService
    {
        ICourierRepository _courierRepository;
        IOrderRepository _orderRepository;

        public CourierManager(ICourierRepository courierRepository, IOrderRepository orderRepository)
        {
            _courierRepository = courierRepository;
            _orderRepository = orderRepository;
        }

        public IDataResult<List<Courier>> GetAll()
        {
            return new SuccessDataResult<List<Courier>>(_courierRepository.GetAll());
        }

        public IDataResult<Courier> GetById(int id)
        {
            return new SuccessDataResult<Courier>(_courierRepository.Get(c => c.Id == id));
        }

        public IDataResult<List<Order>> GetOrders()
        {
            return new SuccessDataResult<List<Order>>(_orderRepository.GetOrders());
        }

        public IResult AcceptDelivery(AssignCourierDTO assignCourierDTO)
        {
            var result = CheckOrderIsReadyForDelivery();

            if (result.Success)

                AssignCourier(assignCourierDTO);

            return new SuccessResult();
        }

        public IResult Add(Courier courier)
        {
            _courierRepository.Add(courier);

            return new SuccessResult();
        }

        public IResult Update(Courier courier)
        {
            _courierRepository.Update(courier);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var courier = _courierRepository.Get(c => c.Id == id);

            _courierRepository.Delete(courier);

            return new SuccessResult();
        }

        public IResult CheckOrderIsReadyForDelivery()
        {
            _orderRepository.Get(o => o.ReadyForDelivery == true);

            return new SuccessResult();
        }

        public IResult AssignCourier(AssignCourierDTO assignCourierDTO)
        {
            var order = new Order
            {
                Id = assignCourierDTO.OrderId,
                UserId = assignCourierDTO.UserId,
                CourierId = assignCourierDTO.CourierId,
                MedicineId = assignCourierDTO.MedicineId,
                OrderNumber = assignCourierDTO.OrderNumber,
                ReadyForDelivery = assignCourierDTO.ReadyForDelivery
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }
    }
}
