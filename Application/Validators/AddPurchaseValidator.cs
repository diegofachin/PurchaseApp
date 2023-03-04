using Application.Handlers.AddPurchase;
using Domain.Validators;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace Application.Validators;

[ExcludeFromCodeCoverage]
public class AddPurchaseValidator : AbstractValidator<AddPurchaseRequestDto>
{
    public AddPurchaseValidator()
    {
        RuleFor(request => request.PersonId)
           .NotEmpty();

        RuleFor(request => request.AppId)
            .NotEmpty();

        RuleFor(request => request.NameOnCreditCard)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(request => request.NumberCard)
            .NotEmpty()
            .Must(NumberCardValidator.Validate);

        RuleFor(request => request.Cvc)
            .NotEmpty();

        RuleFor(request => request.Validate)
            .NotEmpty();

        RuleFor(request => request.Amount)
            .NotEmpty()
            .GreaterThan(0);

    }
}
