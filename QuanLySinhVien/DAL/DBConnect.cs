using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection connection = new SqlConnection("Data Source=HOMEPHO-K8TC9OO;Initial Catalog=SINHVIEN;Integrated Security=True");
        protected void OpenConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        protected void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable loadData(string strSQL)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            OpenConnection();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }
    }
}
