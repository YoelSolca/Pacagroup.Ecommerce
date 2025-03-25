using FluentValidation;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands
{
    public class CreateUserTokenValidator : AbstractValidator<CreateUserTokenCommand>
    {
        public CreateUserTokenValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(5);
        }
    }
}
