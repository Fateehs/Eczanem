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
                             UserId = o.UserId,
                         };
            return result.ToList();
        }
    }
}
