using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.DataAccess;
using Tesodev.DataAccess.Concrete;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<OrderDto> GetAll();
        Guid Create(CreateOrderDto orderCreateDto);
        void Update(UpdateOrderDto orderUpdateDto);
    }
}
