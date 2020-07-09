using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Entity
    {
        public Guid Id  { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
