using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesodev.Core.Entities;

namespace Tesodev.Entites.Concrete
{
    public class Address : IEntity
    {
        [Key]
        public string CityCode { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
