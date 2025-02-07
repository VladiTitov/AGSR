using Bogus;
using MaternityHospital.Domain.Enums;

namespace MaternityHospital.EntityGenerator.Fakers;

internal class PatientFaker : Faker<Patient>
{
    public PatientFaker()
    {
        RuleFor(i => i.Name, f => new NameFaker().Generate());
        RuleFor(i => i.Gender, f => f.PickRandom<Gender>());
        RuleFor(i => i.BirthDate, f => f.Date.Past(10));
        RuleFor(i => i.Active, f => f.Random.Bool());
    }
}
