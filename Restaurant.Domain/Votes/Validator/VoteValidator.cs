using Domain.Votes.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Votes.Validator
{
    internal class VoteValidator : AbstractValidator<Vote>
    {
        public VoteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("O Id é obrigatório");
            RuleFor(x => x.IdUser).NotEmpty().NotNull().WithMessage("O IdUser é obrigatório");
            RuleFor(x => x.IdRestaurant).NotEmpty().NotNull().WithMessage("O IdRestaurant  é obrigatório");
            RuleFor(x => x.Date).NotEmpty().NotNull().LessThan(DateTime.Now).WithMessage("Data inválida");
        }
    }
}
