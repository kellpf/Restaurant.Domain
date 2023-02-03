using Domain.Restaurants.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurants.Validator
{
    internal class CreateRestaurantValidator : AbstractValidator<CreateRestaurant>
    {
        public CreateRestaurantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3)
                .MaximumLength(50).WithMessage("O nome deve conter entre 3 e 50 caracteres");
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(50)
                .MaximumLength(250).WithMessage("A descrição deve conter entre 50 e 250 caracteres");
        }
    }
}
