using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Entities;

namespace Tesodev.Entites.Concrete
{
    public class Order : IEntity
    {
        public Guid Id { get; protected set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public Guid Product { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public void Created()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        public void Updated()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
