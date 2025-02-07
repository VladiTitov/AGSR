namespace MaternityHospital.Domain.Settings;

#nullable disable
public abstract class BaseDbConnection
{
    public Credentials UserCredentials { get; set; }
    public string DatabaseName { get; set; }
    public HostData DbHostData { get; set; }
}
