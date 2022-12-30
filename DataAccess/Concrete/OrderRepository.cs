using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class OrderRepository : EntityRepositoryBase<Order, BaseDbContext>, IOrderRepository
    {
        public OrderRepository(BaseDbContext context) : base(context)
        {
        }

        public List<Order> ListOrdersToBeDelivered()
        {
            var result = from o in Context.Orders
                         where o.ReadyForDelivery == true & o.CourierId == null
                         select new Order
                         {
                             Id = o.Id,
                             CourierId = o.CourierId,
                             MedicineId = o.MedicineId,
                             OrderNumber = o.OrderNumber,
                             ReadyForDelivery = o.ReadyForDelivery,
                             CustomerId = o.CustomerId,
                             PharmacyId = o.PharmacyId,
                         };
            return result.ToList();
        }

        public List<Order> ListOrdersToBePrepared()
        {
            var result = from o in Context.Orders
                         join p in Context.Pharmacies
                         on o.PharmacyId equals p.Id
                         where o.PharmacyId == p.Id
                         select new Order
                         {
                             Id = o.Id,
                             PharmacyId = p.Id,
                             CourierOnTheWay = false,
                             CourierId = null,
                             ConfirmationNumberFromCustomer = o.OrderNumber,
                             CustomerId = o.CustomerId,
                             GetPackageFromPharmacy = o.GetPackageFromPharmacy,
                             GivePackageToCourier = o.GivePackageToCourier,
                             OrderAcceptedFromPharmacy = true,
                             MedicineId = o.MedicineId,
                             OrderDelivered = false,
                             OrderNumber = o.OrderNumber,
                             ReadyForDelivery = false
                         };
            return result.ToList();

        }
    }
}
