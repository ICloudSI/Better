using System;

namespace Better.Core.Domain
{
    public class Enity
    {
        public Guid Id { get; protected set;}

        protected Enity()
        {
            Id= Guid.NewGuid();
        }

    }
}