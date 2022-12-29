using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class CustomerOrderDTO : IDTO
    {
        public int OrderId { get; set; }
        public int PharmacyId { get; set; }
        public int CustomerId { get; set; }
        public int MedicineId { get; set; }
        public int? CourierId { get; set; }
        public bool OrderAcceptedFromPharmacy { get; set; } = false;
        public bool ReadyForDelivery { get; set; } = false;
        public string OrderNumber { get; set; }
    }
}
