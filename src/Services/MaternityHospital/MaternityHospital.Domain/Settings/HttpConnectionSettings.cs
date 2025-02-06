namespace MaternityHospital.Domain.Settings;

public class HttpConnectionSettings : HostData
{
    public new int Port { get; set; } = 80;

    public string Protocol { get; set; } = "http";

    public Uri GetHttpUri()
        => new(this.ToString());

    public override string ToString()
        => (Port.Equals(0))
            ? throw new ArgumentNullException(nameof(Port))
            : $"{Protocol}://{HostName}:{Port}";
}
