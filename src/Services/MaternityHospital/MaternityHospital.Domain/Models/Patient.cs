using MaternityHospital.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace MaternityHospital.Domain.Models;

#nullable disable
/// <summary>
/// Patient model
/// </summary>
public class Patient
{
    /// <summary>
    /// Id property
    /// </summary>
    [BsonId]
    public Guid Id { get; set; }
    /// <summary>
    /// Name property
    /// </summary>
    public Name Name { get; set; }
    /// <summary>
    /// Gender property
    /// </summary>
    public Gender Gender { get; set; }
    /// <summary>
    /// BirthDate property (required)
    /// </summary>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// IsActive property
    /// </summary>
    public bool Active { get; set; }
}

