using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Entites.Concrete;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Business.ValidationRules
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(u => u.CustomerId).NotEmpty();
            RuleFor(u => u.Address).NotEmpty();
            RuleFor(c => c.Address.Country).NotEmpty();
            RuleFor(c => c.Address.CityCode).NotEmpty();
            RuleFor(c => c.Address.City).NotEmpty();
            RuleFor(u => u.Price).NotNull();
            RuleFor(u => u.Product).NotEmpty();
            RuleFor(u => u.Quantity).NotNull();
        }
    }
}
