using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Utilities.Results;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Guid> Create(CreateCustomerDto CreateCustomerDto);
        IResult Update(UpdateCustomerDto updateCustomerDto);
        IResult Delete(Guid customerId);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(Guid customer);
        IResult Validate(Guid id);
    }
}
