using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Model
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string? DetailType { get; set; }
        public string? DetailValue { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
