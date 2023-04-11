using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Data Source=SQL5109.site4now.net;Initial Catalog=db_a7ea75_setprograms;User Id=db_a7ea75_setprograms_admin;Password=Arzafil01";
;
        }
        //"Data Source = (local); Initial Catalog = AlmacenesArzafil; Integrated Security = True"
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static SqlConnection conectate()
        {
            SqlConnection con = new SqlConnection("Data Source=SERVERAZF\\SQLEXPRESS;Initial Catalog=AlmacenesArzafil;user id = sa; password = SerArza2021");
            con.Open();
            return con;

        }
    }
}
