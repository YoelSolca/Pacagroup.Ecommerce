using FluentValidation;
using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UsersDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();/*.WithMessage("El Email es requerido.");*/
            RuleFor(x => x.Password).NotNull().NotEmpty();/*.WithMessage("El Password es requerido.");*/
            //RuleFor(x => x.Password).MinimumLength(8).WithMessage("El Password debe tener al menos 8 caracteres.");
            //RuleFor(x => x.Password).MaximumLength(20).WithMessage("El Password debe tener como máximo 20 caracteres.");
            //RuleFor(x => x.Password).Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$").WithMessage("El Password debe tener al menos una letra mayúscula, una letra minúscula y un número.");
        }
    }
}
