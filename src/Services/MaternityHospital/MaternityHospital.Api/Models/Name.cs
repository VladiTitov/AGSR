namespace MaternityHospital.Api.Models;

public class Name
{
    public string? Use { get; set; }
    public string[]? Given { get; set; }

#nullable disable
    public string Family { get; set; }
}
