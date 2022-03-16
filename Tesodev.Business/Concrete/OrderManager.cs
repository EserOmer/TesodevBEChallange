using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Constants;
using Tesodev.Core.Utilities.Results;
using Tesodev.Business.Abstract;
using Tesodev.DataAccess.Abstract;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;
using Tesodev.Core.Utilities.Business;
using Tesodev.Business.ValidationRules;
using Tesodev.Core.Aspects.Autofac.Validation;
using System.Linq;

namespace Tesodev.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        ICustomerDal _customerDal;
        IProductDal _productDal;

        public OrderManager(IOrderDal orderDal, ICustomerDal customerDal, IProductDal productDal)
        {
            _orderDal = orderDal;
            _customerDal = customerDal;
            _productDal = productDal;
        }
        public IResult ChangeStatus(Guid orderId, string status)
        {
            IResult result = BusinessRules.Run(CheckIfOrderId(orderId));
            if (result != null)
            {
                return result;
            }
            Order order = _orderDal.Get(o => o.Id == orderId);
            order.Updated();
            order.Status = status;
            _orderDal.Update(order);

            return new SuccessResult(Messages.TransactionSuccesful);
        }
        [ValidationAspect(typeof(CreateOrderValidator))]
        public IDataResult<Guid> Create(CreateOrderDto orderCreateDto)
        {
            IResult result = 
                BusinessRules.Run(
                                  CheckIfCustomer(orderCreateDto.CustomerId),
                                  CheckIfProduct(orderCreateDto.Product)
                                  );
            if (result != null)
            {
                return null;
            }
            var createdOrderId= _orderDal.Create(orderCreateDto);
            return new SuccessDataResult<Guid>(createdOrderId,Messages.TransactionSuccesful);
        }

        public IResult Delete(Guid orderId)
        {
            IResult result = BusinessRules.Run(CheckIfOrderId(orderId));
            if (result != null)
            {
                return result;
            }
            var order = _orderDal.Get(o => o.Id == orderId);
            _orderDal.Delete(order);
            return new SuccessResult(Messages.TransactionSuccesful);
        }

        public IDataResult<List<Order>> GetByCustomerId(Guid customerId)
        {
            var result = _orderDal.GetAll(o => o.CustomerId == customerId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Order>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Order>>(result, Messages.TransactionSuccesful);
        }

        public IDataResult<List<OrderDto>> GetAll()
        {
            var result = _orderDal.GetAll();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<OrderDto>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetAll(), Messages.TransactionSuccesful);
        }

        public IDataResult<Order> GetById(Guid orderId)
        {
            var result = _orderDal.Get(o => o.Id == orderId);
            if (result == null)
            {
                return new ErrorDataResult<Order>(Messages.NotFound);
            }
            return new SuccessDataResult<Order>(result, Messages.TransactionSuccesful);
        }
        [ValidationAspect(typeof(UpdateOrderValidator))]
        public IResult Update(UpdateOrderDto orderUpdateDto)
        {
            IResult result = 
                BusinessRules.Run(
                                  CheckIfCustomer(orderUpdateDto.CustomerId),
                                  CheckIfProduct(orderUpdateDto.Product)
                                  );
            if (result != null)
            {
                return result;
            }
            _orderDal.Update(orderUpdateDto);
            return new SuccessResult(Messages.TransactionSuccesful);
        }
        public IResult CheckIfCustomer(Guid customerId)
        {
            var result = _customerDal.Get(c => c.Id == customerId);
            if (result == null)
            {
                return new ErrorResult(Messages.CustomerIdNotFound);
            }
            return new SuccessResult();
        }
        public IResult CheckIfProduct(Guid productId)
        {
            var result = _productDal.Get(c => c.Id == productId);
            if (result == null)
            {
                return new ErrorResult(Messages.ProductIdNotFound);
            }
            return new SuccessResult();
        }
        public IResult CheckIfOrderId(Guid orderId)
        {
            var result = _orderDal.Get(c => c.Id == orderId);
            if (result == null)
            {
                return new ErrorResult(Messages.OrderIdNotFound);
            }
            return new SuccessResult();

        }
    }
}
