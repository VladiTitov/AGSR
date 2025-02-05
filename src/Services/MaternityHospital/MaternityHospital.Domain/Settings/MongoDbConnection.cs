using System.Text;

namespace MaternityHospital.Domain.Settings;

public class MongoDbConnection : BaseDbConnection
{
    public override string ToString()
    {
        var connectionStringBuilder = new StringBuilder("mongodb://");
        if (!UserCredentials.IsNullOrEmpty())
            connectionStringBuilder.Append(
                string.Format("{0}:{1}@", UserCredentials.Username, UserCredentials.Password));
        if (!DbHostData.IsNullOrEmpty() || !string.IsNullOrEmpty(DatabaseName))
            connectionStringBuilder.Append(
                string.Format("{0}:{1}", DbHostData.HostName, DbHostData.Port));
        return connectionStringBuilder.ToString();
    }
}
