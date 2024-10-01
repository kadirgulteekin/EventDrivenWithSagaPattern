using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Model
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
