using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class CourierDTO : IDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string Transport { get; set; }
        public string PlateNumber { get; set; }
        public bool OnDuty { get; set; }
        public bool OffDuty { get; set; }
        public DateTime OnDutyTime { get; set; }
        public DateTime OffDutyTime { get; set; }
        public string ServiceStatus { get; set; }
        public string Status { get; set; }
    }
}
