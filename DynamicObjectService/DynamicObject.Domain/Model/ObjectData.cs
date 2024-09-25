using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Model
{
    public class ObjectData
    {
        public int Id { get; set; }
        public int ObjectFieldId { get; set; }
        public string? ObjectValues { get; set; }
    }
}
