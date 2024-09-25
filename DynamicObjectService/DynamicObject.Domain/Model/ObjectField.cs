using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Model
{
    public class ObjectField
    {
        public int Id { get; set; }
        public Guid DynamicObjectModelId { get; set; }
        public string? ObjectdName { get; set; }
        public string? ObjectType { get; set; }
        public bool? IsRequired { get; set; }
        [Range(0.01, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "At least one ObjectDatas is required.")]
        public List<ObjectData> ObjectDatas { get; set; } = new List<ObjectData> { };
    }
}
