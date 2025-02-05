using MongoDB.Bson.Serialization.Attributes;

namespace MaternityHospital.Api.Models;

#nullable disable
public partial class Patient
{
    [BsonId]
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
