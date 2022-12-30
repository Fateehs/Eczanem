using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PharmacyManager : IPharmacyService
    {
        IPharmacyRepository _pharmacyRepository;
        IOrderRepository _orderRepository;

        public PharmacyManager(IPharmacyRepository pharmacyRepository, IOrderRepository orderRepository)
        {
            _pharmacyRepository = pharmacyRepository;
            _orderRepository = orderRepository;
        }

        public IDataResult<List<Pharmacy>> GetAll()
        {
            return new SuccessDataResult<List<Pharmacy>>(_pharmacyRepository.GetAll());
        }

        public IDataResult<Pharmacy> GetById(int id)
        {
            return new SuccessDataResult<Pharmacy>(_pharmacyRepository.Get(p => p.Id == id));
        }

        public IDataResult<List<Order>> ListOrders()
        {
            return new SuccessDataResult<List<Order>>(_orderRepository.ListOrdersToBePrepared());
        }

        public IResult GivePackageToCourier(Order order)
        {
            var result = _orderRepository.Get(o => o.CourierId == order.CourierId);

            if (result != null)

                ChangePackageStatus(order);

            return new SuccessResult();

        }

        public IResult AcceptOrderFromCustomer(Order order)
        {
            var result = ChangeAcceptStatus(order);

            if (!result.Success) return new ErrorResult();

            return new SuccessResult();
        }

        public IResult ReadyForDelivery(Order order)
        {
            var result = CheckTheOrderIsReadyForDelivery(order);

            if (!result.Success) return new ErrorResult();

            ChangeDeliveryStatus(order);

            return new SuccessResult();
        }

        public IResult Add(Pharmacy pharmacy)
        {
            _pharmacyRepository.Add(pharmacy);

            return new SuccessResult();
        }

        public IResult Update(Pharmacy pharmacy)
        {
            _pharmacyRepository.Update(pharmacy);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var pharmacy = _pharmacyRepository.Get(p => p.Id == id);

            if (pharmacy != null)

                _pharmacyRepository.Delete(pharmacy);

            return new SuccessResult();
        }

        public IResult CheckTheOrderIsReadyForDelivery(Order order)
        {
            _orderRepository.Get(o => o.ReadyForDelivery != true);

            return new SuccessResult();
        }

        public IResult ChangeDeliveryStatus(Order order)
        {
            order = new Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CourierId = null,
                MedicineId = order.MedicineId,
                OrderNumber = order.OrderNumber,
                ReadyForDelivery = true,
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }

        public IResult ChangeAcceptStatus(Order order)
        {
            order = new Order
            {
                OrderAcceptedFromPharmacy = true
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }

        public IResult ChangePackageStatus(Order order)
        {
            order = new Order
            {
                GivePackageToCourier = true,
                CourierOnTheWay = true
            };

            _orderRepository.Update(order);

            return new SuccessResult();
        }
    }
}
