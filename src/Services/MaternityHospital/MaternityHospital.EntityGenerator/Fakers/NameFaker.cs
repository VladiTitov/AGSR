using Bogus;

namespace MaternityHospital.EntityGenerator.Fakers;

internal class NameFaker : Faker<Name>
{
    public NameFaker()
    {
        RuleFor(i => i.Use, f => "official");
        RuleFor(i => i.Given, f => f.Name.Random.WordsArray(0, 2));
        RuleFor(i => i.Family, f => f.Name.LastName());
    }
}
