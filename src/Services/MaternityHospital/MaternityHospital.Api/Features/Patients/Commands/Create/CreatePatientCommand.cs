using System.ComponentModel.DataAnnotations;

namespace MaternityHospital.Api.Features.Patients.Commands.Create;

#nullable disable
public class CreatePatientCommand : IRequest<Guid>
{
    public Name Name { get; set; }

    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
