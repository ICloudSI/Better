using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Participant : Entity
    {
        public string Name { get; set; }

        public Participant(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
