using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Constants;
using Tesodev.Core.Utilities.Results;
using Tesodev.Business.Abstract;
using Tesodev.DataAccess.Abstract;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;
using Tesodev.Core.Aspects.Autofac.Validation;
using Tesodev.Business.ValidationRules;
using Tesodev.Core.Utilities.Business;

namespace Tesodev.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IOrderDal _orderDal;

        public CustomerManager(ICustomerDal customerDal,IOrderDal orderDal)
        {
            _customerDal = customerDal;
            _orderDal = orderDal;   
        }
        [ValidationAspect(typeof(CreateCustomerValidator))]
        public IDataResult<Guid> Create(CreateCustomerDto createCustomerDto)
        {
            var createdCustomerId = _customerDal.Create(createCustomerDto);
            return new SuccessDataResult<Guid>(createdCustomerId, Messages.TransactionSuccesful);
        }

        public IResult Delete(Guid customerId)
        {
            IResult result = BusinessRules.Run(CheckIfCustomerId(customerId));
            if (result != null)
            {
                return result;
            }
            List<Order> deletedOrder=_orderDal.GetAll(o => o.CustomerId == customerId);
            foreach (var order in deletedOrder)
            {
                _orderDal.Delete(order);
            }
            var customer = _customerDal.Get(c => c.Id == customerId);
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.TransactionSuccesful);
        }

        public IDataResult<Customer> GetById(Guid customerId)
        {
            var result = _customerDal.Get(o => o.Id == customerId);
            if (result == null)
            {
                return new ErrorDataResult<Customer>(Messages.NotFound);
            }
            return new SuccessDataResult<Customer>(result, Messages.TransactionSuccesful);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<Customer>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.TransactionSuccesful);
        }

        [ValidationAspect(typeof(UpdateCustomerValidator))]
        public IResult Update(UpdateCustomerDto updateCustomerDto)
        {
            _customerDal.Update(updateCustomerDto);
            return new SuccessResult(Messages.TransactionSuccesful);
        }

        public IResult Validate(Guid id)
        {
            if (_customerDal.Validate(id))
            {
                return new SuccessResult(Messages.ValidateSuccesful);
            }
            return new ErrorResult(Messages.ValidateError);
        }
        public IResult CheckIfCustomerId(Guid customerId)
        {
            var result = _customerDal.Get(c => c.Id == customerId);
            if (result == null)
            {
                return new ErrorResult(Messages.CustomerIdNotFound);
            }
            return new SuccessResult();

        }
    }
}
