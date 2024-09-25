using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    public class CreateObjectMesssageCommand
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Object Type is required.")]
        public string? ObjectType { get; set; }
        public string? ObjectDescription { get; set; }
        public bool IsActive { get; set; }
        public List<ObjectFieldMessage> ObjectFields { get; set; } = new List<ObjectFieldMessage> { };
    }

    public class ObjectFieldMessage
    {
        public int Id { get; set; }
        public Guid DynamicObjectModelId { get; set; }
        public string? ObjectdName { get; set; }
        public string? ObjectType { get; set; }
        public bool? IsRequired { get; set; }
        [Range(0.01, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }
        public List<ObjectData> ObjectDatas { get; set; } = new List<ObjectData> { };

    }


    public class ObjectData
    {
        public int Id { get; set; }
        public int ObjectFieldId { get; set; }
        public string? ObjectValues { get; set; }
    }
}
