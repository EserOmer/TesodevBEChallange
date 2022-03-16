using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.DataAccess;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        bool Validate(Guid customerId);
        Guid Create(CreateCustomerDto createCustomerDto);
        void Update(UpdateCustomerDto updateCustomerDto);
    }
}
