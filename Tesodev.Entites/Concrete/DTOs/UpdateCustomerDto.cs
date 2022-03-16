using System;
using System.Collections.Generic;
using System.Text;

namespace Tesodev.Entites.Concrete.DTOs
{
    public class UpdateCustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
