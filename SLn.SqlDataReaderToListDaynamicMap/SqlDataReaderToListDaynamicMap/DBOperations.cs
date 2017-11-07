using SqlDataReaderToListDaynamicMap.Configarations;
using SqlDataReaderToListDaynamicMap.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlDataReaderToListDaynamicMap
{
    public class DBOperations
    {
        private readonly IMSSQLConn mssqlConn = null;
        private SqlConnection sqlConnection = null;
        private string sqlQuery1 = "select * from Customers";
        public DBOperations()
        {
            mssqlConn = new MSSQLConn();
            sqlConnection = mssqlConn.connMSSQLDB;
        }



        public List<Customers> GetAllCustomers()
        {
            SqlDataReader myReader = null;
            List<Customers> listCustomers = new List<Customers>();

            try
            {
                sqlConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(sqlQuery1, sqlConnection))
                {
                    myReader = myCommand.ExecuteReader();
                }

                while (myReader.Read())
                {
                    listCustomers.Add(new Customers
                    {
                        CustomerID = myReader["CustomerID"] == DBNull.Value ? 0 : Convert.ToInt64(myReader["CustomerID"]),

                        CustomerName = myReader["CustomerName"] == DBNull.Value ? null : myReader["CustomerName"].ToString(),
                        CustomerEmail = myReader["CustomerEmail"] == DBNull.Value ? null : myReader["CustomerEmail"].ToString(),
                        CustomerZipCode = myReader["CustomerZipCode"] == DBNull.Value ? 0 : Convert.ToInt64(myReader["CustomerZipCode"]),

                        CustomerCountry = myReader["CustomerCountry"] == DBNull.Value ? null : myReader["CustomerCountry"].ToString(),
                        CustomerCity = myReader["CustomerCity"] == DBNull.Value ? null : myReader["CustomerCity"].ToString(),

                    });
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return listCustomers;
        }

        public List<Customers> GetAllCustomersDynamicMap()
        {
            SqlDataReader myReader = null;
            List<Customers> listCustomers = new List<Customers>();

            try
            {
                sqlConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(sqlQuery1, sqlConnection))
                {
                    myReader = myCommand.ExecuteReader();
                }

                listCustomers = myReader.DataReaderToList<Customers>();


                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return listCustomers;
        }

    }
}
