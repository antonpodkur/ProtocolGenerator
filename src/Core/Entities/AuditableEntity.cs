using System;

namespace Core.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
    }
}