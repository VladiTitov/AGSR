using System.ComponentModel.DataAnnotations;

namespace MaternityHospital.Api.Features.Patients.Commands.Create;

#nullable disable
/// <summary>
/// Create patient model
/// </summary>
public class CreatePatientCommand : IRequest<Guid>
{
    /// <summary>
    /// Name property
    /// </summary>
    public Name Name { get; set; }

    /// <summary>
    /// Gender property
    /// </summary>
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    /// <summary>
    /// BirthDate property
    /// </summary>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// Active propetry
    /// </summary>
    public bool Active { get; set; }
}
