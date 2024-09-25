using DynamicObject.API.EventBus.Event;
using DynamicObject.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace DynamicObject.API.EventBus.Events
{
    public class ObjectCreatedEvent
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Object Type is required.")]
        public string? ObjectType { get; set; }

        public string? ObjectDescription { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "At least one ObjectItem is required.")]
        public List<ObjectField> ObjectFields { get; set; } = new List<ObjectField>();

    }
}
