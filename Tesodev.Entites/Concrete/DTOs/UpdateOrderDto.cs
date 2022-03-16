using System;
using System.Collections.Generic;
using System.Text;

namespace Tesodev.Entites.Concrete.DTOs
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Guid Product { get; set; }
    }
}
