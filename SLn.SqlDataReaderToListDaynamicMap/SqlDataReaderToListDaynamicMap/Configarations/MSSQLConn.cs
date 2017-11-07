using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SqlDataReaderToListDaynamicMap.Configarations
{
    public class MSSQLConn : IMSSQLConn
    {
        public SqlConnection connMSSQLDB
        {
            get
            {
                return GetMSSQLConn();
            }
        }

        public SqlConnection GetMSSQLConn()
        {
            SqlConnection connMSSQLDB = null;
            try
            {
                connMSSQLDB = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQLDBConn"].ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connMSSQLDB;
        }


    }
}
