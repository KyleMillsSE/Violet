using DotNetCore2.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCore2.Model.Entities
{
    public abstract class MutableEntity : IMutableEntity, IEntity, IVersionedEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid ModifiedById { get; set; }
        [ConcurrencyCheck]
        [Required]
        [Timestamp]
        public byte[] Version { get; set; }
        [ForeignKey("CreatedById")]
        public virtual CoreUser CreatedBy { get; set; }
        [ForeignKey("ModifiedById")]
        public virtual CoreUser ModifiedBy { get; set; }
    }
}
