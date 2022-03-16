using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Entities;

namespace Tesodev.Entites.Concrete
{
    public class Customer : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get;protected set; }
        public DateTime UpdatedAt { get;protected set; }
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
