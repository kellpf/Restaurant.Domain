using Domain.Users.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Validator
{
    internal class UserValidator : AbstractValidator<User>
    { 
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("O Id é obrigatório");
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(4).MaximumLength(50).WithMessage("O nome deve conter entre 4 e 50 caracteres");
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(8).WithMessage("A senha deve conter 8 caracteres");
            RuleFor(x => x.Password).NotEmpty().NotNull().EmailAddress().WithMessage("E-mail invalido");
        }
    }
}
