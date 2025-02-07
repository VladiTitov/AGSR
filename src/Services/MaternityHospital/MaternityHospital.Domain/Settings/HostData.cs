namespace MaternityHospital.Domain.Settings;

public class HostData
{
    public string HostName { get; set; } = "localhost";
    public int Port { get; set; }

    public bool IsNullOrEmpty()
        => this is null ||
        string.IsNullOrEmpty(this.HostName) ||
        this.Port == 0;
}
