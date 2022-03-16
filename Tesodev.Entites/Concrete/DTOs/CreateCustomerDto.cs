using System;
using System.Collections.Generic;
using System.Text;

namespace Tesodev.Entites.Concrete.DTOs
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
