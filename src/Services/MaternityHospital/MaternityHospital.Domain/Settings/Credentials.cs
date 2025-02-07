namespace MaternityHospital.Domain.Settings;

#nullable disable
public class Credentials
{
    public string Username { get; set; }
    public string Password { get; set; }

    public bool IsNullOrEmpty()
        => this is null ||
        string.IsNullOrEmpty(this.Username) ||
        string.IsNullOrEmpty(this.Password);
}
