using FluentValidation;

namespace MaternityHospital.Api.Features.Patients.Commands;

public class NameValidator : AbstractValidator<Name>
{
    private const string IsRequiredProperty = "This property is required";

    public NameValidator()
    {
        RuleFor(_ => _.Family).NotNull().NotEmpty().WithMessage(IsRequiredProperty);
    }
}
