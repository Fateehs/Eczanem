using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Confirmation;
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

        public IDataResult<List<Order>> ListOrdersToBeDelivered()
        {
            return new SuccessDataResult<List<Order>>(_orderRepository.ListOrdersToBeDelivered());
        }

        public IResult OrderDelivered(Order order)
        {
            var result = _orderRepository.Get(o => o.OrderNumber == order.OrderNumber);

            if (result != null)

                ChangeDeliveredStatus(order);

            return new SuccessResult();
        }

        public IResult AcceptDelivery(Order order)
        {
            AssignCourier(order);

            return new SuccessResult();
        }

        public IResult GetPackage(Order order)
        {
            var result = _orderRepository.Get(o => o.OrderNumber == order.OrderNumber);

            if (result != null)

                ChangePackageStatus(order);

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

        public IResult AssignCourier(Order order)
        {
            order = new Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CourierId = order.CourierId,
                MedicineId = order.MedicineId,
                PharmacyId = order.PharmacyId,
                OrderNumber = order.OrderNumber,
                ConfirmationNumberFromCustomer = order.OrderNumber,
                ReadyForDelivery = true,
                OrderAcceptedFromPharmacy = true,
                CourierOnTheWay = false,
                GetPackageFromPharmacy  = false,
                GivePackageToCourier = false,
                OrderDelivered = false,
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }

        public IResult ChangePackageStatus(Order order)
        {
            order = new Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CourierId = order.CourierId,
                MedicineId = order.MedicineId,
                PharmacyId = order.PharmacyId,
                OrderNumber = order.OrderNumber,
                ConfirmationNumberFromCustomer = order.OrderNumber,
                ReadyForDelivery = true,
                OrderAcceptedFromPharmacy = true,
                CourierOnTheWay = true,
                GivePackageToCourier = true,
                GetPackageFromPharmacy = true,
                OrderDelivered = true,
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }

        public IResult ChangeDeliveredStatus(Order order)
        {
            order = new Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CourierId = order.CourierId,
                MedicineId = order.MedicineId,
                PharmacyId = order.PharmacyId,
                OrderNumber = order.OrderNumber,
                ConfirmationNumberFromCustomer = order.OrderNumber,
                ReadyForDelivery = true,
                OrderAcceptedFromPharmacy = true,
                CourierOnTheWay = true,
                GivePackageToCourier = true,
                GetPackageFromPharmacy = true,
                OrderDelivered = false,
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }
    }
}
