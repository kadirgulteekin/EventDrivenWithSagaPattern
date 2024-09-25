using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Model
{
    public class DynamicObjectModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Object Type is required.")]
        public string? ObjectType { get; set; }
        public string? ObjectDescription { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "At least one ObjectFields is required.")]
        public List<ObjectField> ObjectFields { get; set; } = new List<ObjectField> { };
    }

}
