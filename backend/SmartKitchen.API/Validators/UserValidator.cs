using FluentValidation;
using Smartkitchen.API.Models;
using System.Text.RegularExpressions;

namespace Smartkitchen.API.Validators
{
    public class UserValidator : UserValidatorBase<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("O nome é obrigatório.")
               .MaximumLength(255).WithMessage("O nome deve ter no máximo 255 caracteres.")
               .MinimumLength(2).WithMessage("O nome está muito curto.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");
            RuleFor(x => x.Password)
                .Must(IsValidPassword).WithMessage("A senha deve ter no mínimo 8 caracteres, incluindo letras maiúsculas e minúsculas, números e caracteres especiais.");
            RuleFor(x => x.Username)
               .NotEmpty().WithMessage("O Nome do Usuário é obrigatório.")
               .MaximumLength(255).WithMessage("O nome deve ter no máximo 255 caracteres.")
               .MinimumLength(2).WithMessage("O nome está muito curto.");
        }


        private bool IsValidPassword(string password)
        {
            // Implemente a lógica de validação de senha forte aqui
            // Exemplo: verificar se a senha tem pelo menos 8 caracteres, letras maiúsculas e minúsculas, números e caracteres especiais.
            // Você pode usar expressões regulares ou outras bibliotecas para auxiliar na validação.

            // Exemplo de validação usando expressão regular:
            var hasMinimum8Chars = new Regex(@".{8,}");
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            return hasMinimum8Chars.IsMatch(password)
                   && hasNumber.IsMatch(password)
                   && hasUpperChar.IsMatch(password)
                   && hasLowerChar.IsMatch(password)
                   && hasSymbols.IsMatch(password);
        }
    }
}
