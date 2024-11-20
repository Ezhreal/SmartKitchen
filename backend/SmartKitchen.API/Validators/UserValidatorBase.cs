using FluentValidation;
using Smartkitchen.API.Models;

namespace Smartkitchen.API.Validators
{
    public class UserValidatorBase<T> : AbstractValidator<T> where T : UserBase
    {
        public UserValidatorBase() 
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(255).WithMessage("O nome deve ter no máximo 255 caracteres.")
            .MinimumLength(2).WithMessage("O nome está muito curto.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");
        }
    }
}
