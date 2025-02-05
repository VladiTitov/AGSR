using System.ComponentModel.DataAnnotations;

namespace MaternityHospital.Api.Features.Patients.Commands.Update;

#nullable disable
public class UpdatePatientCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public Name Name { get; set; }

    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
