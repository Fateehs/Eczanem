using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class AssignCourierDTO : IDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CourierId { get; set; }
        public int MedicineId { get; set; }
        public string OrderNumber { get; set; }
        public bool ReadyForDelivery { get; set; }
    }
}
