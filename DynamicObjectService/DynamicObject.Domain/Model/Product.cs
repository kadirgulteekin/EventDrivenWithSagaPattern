﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public ICollection<ProductDetail>? Details { get; set; }
        public ICollection<ProductImage>? Images { get; set; }
    }
}

