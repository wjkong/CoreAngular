using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Data.SqlClient;

namespace Konger.CoreAngular.DAL
{
    public class DataAccessBase
    {
        private IMemoryCache _memoryCache;

        public DataAccessBase()
        {

        }

        public DataAccessBase(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(GetDBConnectionString());
        }

        private string GetDBConnectionString()
        {
            string connectionStr = string.Empty;
            string keyConnectionStr = "keyConn";
            try
            {
                if (!this._memoryCache.TryGetValue(keyConnectionStr, out connectionStr))
                {
                    //if (string.IsNullOrEmpty(connectionStr))
                    //    connectionStr = @"Data Source=kongsqldb.cugvbjkpc2us.ca-central-1.rds.amazonaws.com;Initial Catalog=awsdb;Integrated Security=false;User ID=wjkong;Password=Wj730615!";

                    var creds = new InstanceProfileAWSCredentials();
                    var ssmClient = new AmazonSimpleSystemsManagementClient(creds);
                    var request = new GetParameterRequest()
                    {
                        Name = "/kongsolution/Prod/ConnectionStr",
                        WithDecryption = true
                    };

                    var response = ssmClient.GetParameterAsync(request).GetAwaiter().GetResult();

                    if (response.Parameter != null)
                    {
                        connectionStr = response.Parameter.Value;

                        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(7));

                        this._memoryCache.Set(keyConnectionStr, connectionStr, cacheEntryOptions);
                    }

                }
            }
            catch
            {

            }


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
