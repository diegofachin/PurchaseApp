using Application.Handlers.AddApp;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators;

[ExcludeFromCodeCoverage]
public class AddAppValidator : AbstractValidator<AddAppRequestDto>
{
    public AddAppValidator()
    {
        RuleFor(request => request.Name)
           .NotEmpty()
           .MinimumLength(3);

        RuleFor(request => request.Price)
            .NotEmpty()
            .GreaterThan(0);
    }
}
