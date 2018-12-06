using System.Data.SqlClient;

namespace Konger.CoreAngular.DAL
{
    public class DataAccessBase
    {
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(GetDBConnectionString());
        }

        private string GetDBConnectionString()
        {
            string connectionStr = string.Empty;

            //try
            //{
            //    var creds = new InstanceProfileAWSCredentials();
            //    var ssmClient = new AmazonSimpleSystemsManagementClient(creds);
            //    var request = new GetParameterRequest()
            //    {
            //        Name = "/kongsolution/Prod/ConnectionStr",
            //        WithDecryption = true
            //    };

            //    var response = ssmClient.GetParameterAsync(request).GetAwaiter().GetResult();

            //    if (response.Parameter != null)
            //    {
            //        connectionStr = response.Parameter.Value;

            //    }

            //}
            //catch
            //{

            //}

            if (string.IsNullOrEmpty(connectionStr))
                connectionStr = @"Data Source=kongsqldb.cugvbjkpc2us.ca-central-1.rds.amazonaws.com;Initial Catalog=awsdb;Integrated Security=false;User ID=wjkong;Password=Wj730615!";

            return connectionStr;
        }

        //private DbConnection CreateConnection()
        //{
        //    DbConnection conn = null;

        //    if (connStrSetting.ProviderName.Eq("System.Data.SqlClient"))
        //    {
        //        conn = new SqlConnection();
        //    }
        //    //else if (connStrSetting.ProviderName.Eq("Oracle.ManagedDataAccess.Client"))
        //    //{
        //    //    conn = new OracleConnection();
        //    //}
        //    else
        //    {
        //        var factory = DbProviderFactories.GetFactory(connStrSetting.ProviderName);

        //        conn = factory.CreateConnection();
        //    }

        //    conn.ConnectionString = connStrSetting.ConnectionString;

        //    return conn;

        //}
    }
}
