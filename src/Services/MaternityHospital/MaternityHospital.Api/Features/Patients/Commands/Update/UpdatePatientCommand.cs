using System.ComponentModel.DataAnnotations;

namespace MaternityHospital.Api.Features.Patients.Commands.Update;

#nullable disable
/// <summary>
/// Update property command
/// </summary>
public class UpdatePatientCommand : IRequest<bool>
{
    /// <summary>
    /// Id property
    /// </summary>
    public Guid Id { get; set; }
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
    /// IsActive property
    /// </summary>
    public bool Active { get; set; }
}
