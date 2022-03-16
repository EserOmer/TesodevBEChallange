using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tesodev.Core.DataAccess.EntityFramework;
using Tesodev.DataAccess.Abstract;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.DataAccess.Concrete
{
    public class OrderDal : EfEntityRepositoryBase<Order, TesodevContext>, IOrderDal
    {
        public Guid Create(CreateOrderDto orderCreateDto)
        {
            using (var context = new TesodevContext())
            {
                Order order = new Order()
                {
                    CustomerId = orderCreateDto.CustomerId,
                    Price = orderCreateDto.Price,
                    Quantity = orderCreateDto.Quantity,
                    Status = orderCreateDto.Status,
                    Product = orderCreateDto.Product,
                    Address = orderCreateDto.Address.AddressLine +
                                "," +
                                orderCreateDto.Address.City +
                                "," +
                                orderCreateDto.Address.CityCode +
                                "," +
                                orderCreateDto.Address.Country,
                };
                order.Updated();
                order.Created();
                var addAddress = context.Entry(orderCreateDto.Address);
                addAddress.State = EntityState.Added;
                var addedorder = context.Entry(order);
                addedorder.State = EntityState.Added;
                context.SaveChanges();
                return order.Id;
            }
        }

        public List<OrderDto> GetAll()
        {
            using (var context = new TesodevContext())
            {
                List<Order> orderList = context.Set<Order>().ToList();
                List<OrderDto> orderDtoList = new List<OrderDto>();
                foreach (var order in orderList)
                {
                    orderDtoList.Add(new OrderDto()
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        Quantity = order.Quantity,
                        Price = order.Price,
                        Product = context.Set<Product>().FirstOrDefault(a => a.Id == order.Product),
                        Address = order.Address,
                        Status = order.Status,
                        CreatedAt = order.CreatedAt,
                        UpdatedAt = order.UpdatedAt,
                    });
                }
                return orderDtoList;
            }
        }
        public void Update(UpdateOrderDto orderUpdateDto)
        {
            using (var context = new TesodevContext())
            {
                Order order = context.Set<Order>().FirstOrDefault(o => o.Id == orderUpdateDto.Id);
                order.CustomerId = orderUpdateDto.CustomerId;
                order.Price = orderUpdateDto.Price;
                order.Quantity = orderUpdateDto.Quantity;
                order.Status = orderUpdateDto.Status;
                order.Product = orderUpdateDto.Product;
                order.Address = orderUpdateDto.Address.AddressLine +
                                "," +
                                orderUpdateDto.Address.City +
                                "," +
                                orderUpdateDto.Address.CityCode +
                                "," +
                                orderUpdateDto.Address.Country;

                order.Updated();
                var addAddress = context.Entry(orderUpdateDto.Address);
                addAddress.State = EntityState.Added;
                var addedorder = context.Entry(order);
                addedorder.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
