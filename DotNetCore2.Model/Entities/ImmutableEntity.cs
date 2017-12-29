using DotNetCore2.Model.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore2.Model.Entities
{
    public abstract class ImmutableEntity : IImmutableEntity, IEntity, IVersionedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        [ConcurrencyCheck]
        [Required]
        [Timestamp]
        public byte[] Version { get; set; }
        [ForeignKey("CreatedById")]
        public virtual CoreUser CreatedBy { get; set; }
    }
}
