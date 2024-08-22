using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set;}

        public bool Equals(Entity? other)
        {
            return Id.Equals(other?.Id);
        }
    }
}
