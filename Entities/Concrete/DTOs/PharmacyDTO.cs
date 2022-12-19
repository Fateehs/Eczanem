using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class PharmacyDTO : IDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Medicine { get; set; }
        public bool License { get; set; }
        public DateTime OnServiceTime { get; set; }
        public DateTime OffServiceTime { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
