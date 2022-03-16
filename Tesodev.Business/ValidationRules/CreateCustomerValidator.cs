using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Entites.Concrete.DTOs;

namespace Tesodev.Business.ValidationRules
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c=>c.Email).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Address.Country).NotEmpty();
            RuleFor(c => c.Address.CityCode).NotEmpty();
            RuleFor(c => c.Address.City).NotEmpty();
        }
    }
}
