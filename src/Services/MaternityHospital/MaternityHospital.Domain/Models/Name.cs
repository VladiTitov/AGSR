namespace MaternityHospital.Domain.Models;

/// <summary>
/// Name model
/// </summary>
public class Name
{
    /// <summary>
    /// Use propery
    /// </summary>
    public string? Use { get; set; }

    /// <summary>
    /// Given property
    /// </summary>
    public string[]? Given { get; set; }

#nullable disable
    /// <summary>
    /// Family property (required)
    /// </summary>
    public string Family { get; set; }
}
