using System.Data.SqlClient;

namespace SqlDataReaderToListDaynamicMap.Configarations
{
    public interface IMSSQLConn
    {
        SqlConnection connMSSQLDB { get; }
    }
}
