using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesodev.Core.DataAccess.EntityFramework;
using Tesodev.DataAccess.Abstract;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.DataAccess.Concrete
{
    public class CustomerDal : EfEntityRepositoryBase<Customer, TesodevContext>, ICustomerDal
    {
        public Guid Create(CreateCustomerDto createCustomerDto)
        {
            using (var context = new TesodevContext())
            {
                Customer customer = new Customer()
                {
                    Email = createCustomerDto.Email,
                    Name = createCustomerDto.Name,
                    Address = createCustomerDto.Address.AddressLine +
                                "," +
                                createCustomerDto.Address.City +
                                "," +
                                createCustomerDto.Address.CityCode +
                                "," +
                                createCustomerDto.Address.Country,
                };
                customer.Updated();
                customer.Created();
                var addAddress = context.Entry(createCustomerDto.Address);
                addAddress.State = EntityState.Added;
                var addedCustomer = context.Entry(customer);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
                return customer.Id;
            }
        }

        public void Update(UpdateCustomerDto updateCustomerDto)
        {
            using (var context = new TesodevContext())
            {
                Customer customer = context.Set<Customer>().FirstOrDefault(o => o.Id == updateCustomerDto.Id);
                customer.Name = updateCustomerDto.Name;
                customer.Email = updateCustomerDto.Email;
                customer.Address = updateCustomerDto.Address.AddressLine +
                                "," +
                                updateCustomerDto.Address.City +
                                "," +
                                updateCustomerDto.Address.CityCode +
                                "," +
                                updateCustomerDto.Address.Country;

                customer.Updated();
                var addAddress = context.Entry(updateCustomerDto.Address);
                addAddress.State = EntityState.Added;

                var addedorder = context.Entry(customer);
                addedorder.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public bool Validate(Guid customerId)
        {
            using (TesodevContext context = new TesodevContext())
            {
                var customer = context.Set<Customer>().SingleOrDefault(x => x.Id == customerId);
                if (customer == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
