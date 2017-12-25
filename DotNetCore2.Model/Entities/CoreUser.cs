using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore2.Model.Entities
{
    public class CoreUser : IAuditedEntity, IVersionedEntity, ISoftEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid ModifiedById { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Version { get; set; }
        public virtual CoreUser CreatedBy { get; set; }
        public virtual CoreUser ModifiedBy { get; set; }
        public virtual ICollection<CoreClaim> Claims { get; set; }
      
    }
}
