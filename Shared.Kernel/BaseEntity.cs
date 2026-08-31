using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Kernel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
