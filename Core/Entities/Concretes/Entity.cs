using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstracts;

namespace Core.Entities.Concretes
{
    public class Entity : IEntity
    {
        public int Id { get; set; }

        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;
        }
    }
}
