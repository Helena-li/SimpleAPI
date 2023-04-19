using FluentValidation;

namespace Simple.API.Models.Validator;

public class ClientValidator: AbstractValidator<ClientModel>
{
    public ClientValidator()
    {
        RuleFor(x => x.Name).NotNull().MinimumLength(4);

        RuleFor(x => x.Email).MaximumLength(100);
    }
}