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
        public int PharmacyId { get; set; }
        public int CustomerId { get; set; }
        public int MedicineId { get; set; }
        public int? CourierId { get; set; }
        public bool OrderDelivered { get; set; } = false;
        public bool CourierOnTheWay { get; set; } = false;
        public bool GetPackageFromPharmacy { get; set; } = false;
        public bool GivePackageToCourier { get; set; } = false;
        public bool OrderAcceptedFromPharmacy { get; set; } = false;
        public bool ReadyForDelivery { get; set; } = false;
        public string ConfirmationNumberFromCustomer { get; set; }
        public string OrderNumber { get; set; }
    }
}
