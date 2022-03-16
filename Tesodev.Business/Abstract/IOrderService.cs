using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Utilities.Results;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Guid> Create(CreateOrderDto createOrderDto);
        IResult Update(UpdateOrderDto updateOrderDto);
        IResult Delete(Guid orderId);
        IDataResult<List<OrderDto>> GetAll();
        IDataResult<List<Order>> GetByCustomerId(Guid customerId);
        IDataResult<Order> GetById(Guid orderId);
        IResult ChangeStatus(Guid orderId, string status);

    }
}
