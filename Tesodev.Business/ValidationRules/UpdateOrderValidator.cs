using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Business.ValidationRules
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
            RuleFor(u => u.CustomerId).NotEmpty();
            RuleFor(u => u.Address).NotEmpty();
            RuleFor(u => u.Price).NotNull();
            RuleFor(u => u.Product).NotEmpty();
            RuleFor(u => u.Quantity).NotNull();
            RuleFor(u => u.Status).NotEmpty();
            RuleFor(u => u.Address.Country).NotEmpty();
            RuleFor(u => u.Address.City).NotEmpty();
            RuleFor(u => u.Address.CityCode).NotEmpty();
        }
    }
}
