using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public int? CourierId { get; set; }
        public bool ReadyForDelivery { get; set; } = false;
        public string OrderNumber { get; set; }
    }
}
