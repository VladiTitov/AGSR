using FluentValidation;

namespace MaternityHospital.Api.Features.Patients.Commands.Create;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    private const string IsRequiredProperty = "This property is required";

    public CreatePatientCommandValidator()
    {
        RuleFor(_ => _.Name)
            .NotNull().WithMessage(IsRequiredProperty)
            .NotEmpty().WithMessage(IsRequiredProperty)
            .SetValidator(new NameValidator());
        RuleFor(_ => _.Gender)
            .IsInEnum().WithMessage($"Invalid value {nameof(Gender)}");
        RuleFor(_ => _.BirthDate)
            .NotEmpty().WithMessage(IsRequiredProperty)
            .Must(val => val <= DateTime.Now).WithMessage("Date of birth cannot be greater than the current date");
    }
}

