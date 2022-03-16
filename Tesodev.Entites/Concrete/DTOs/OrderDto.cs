using System;
using System.Collections.Generic;
using System.Text;

namespace Tesodev.Entites.Concrete.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime UpdatedAt { get;  set; }
    }
}
