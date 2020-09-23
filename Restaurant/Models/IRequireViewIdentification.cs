using System;

namespace Restaurant.Models
{
    public interface IRequireViewIdentification
    {
        public Guid ViewId { get; }
    }
}
