using Konger.CoreAngular.Model;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Konger.CoreAngular.DAL
{
    public abstract class SQLHelper
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static SqlCommand CreateCommand(string comText)
        {
            var command = new SqlCommand
            {
                CommandText = comText,
                CommandType = CommandType.StoredProcedure,
                Connection = GetConnection()

            };

            return command;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static void CreateCommand(SqlCommand com, string comText)
        {
            com.CommandText = comText;
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = GetConnection();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static void CreateQuery(SqlCommand com, string comText)
        {
            com.CommandText = comText;
            com.CommandType = CommandType.Text;
            com.Connection = GetConnection();
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ApiExpertConn"].ToString());
        }

        public static SqlParameter PrepareOutputParam(SqlCommand com, string param)
        {
            var parameter = new SqlParameter(param, SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
                Value = 0
            };

            com.Parameters.Add(parameter);
            return parameter;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static DataSet PrepareTables(string[] comText)
        {
            var dataSet = new DataSet();
            var com = new SqlCommand();

            using (var adapter = new SqlDataAdapter())
            {
                for (int i = 0; i < comText.Length; i++)
                {
                    if (i == Utility.FIRST_TIME)
                    {
                        CreateCommand(com, comText[i]);
                        com.Connection.Open();
                    }
                    else
                    {
                        com.CommandText = comText[i];
                    }
                    adapter.SelectCommand = com;
                    adapter.Fill(dataSet, comText[i]);
                }
            }

            com.Connection.Close();
            return dataSet;
        }
    }
}
