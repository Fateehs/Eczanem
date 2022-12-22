using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Medicine : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrescriptionType { get; set; }
        public bool InStock { get; set; }
        public string Stock { get; set; }
    }
}
