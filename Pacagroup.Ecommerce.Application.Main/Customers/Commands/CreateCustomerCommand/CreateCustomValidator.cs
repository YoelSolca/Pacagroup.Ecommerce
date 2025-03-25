using FluentValidation;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull().MinimumLength(5);
        }
    }
}
