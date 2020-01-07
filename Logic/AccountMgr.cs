using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Konger.CoreAngular.DAL;
using Konger.CoreAngular.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Konger.CoreAngular.Logic
{
    public interface IAccountMgr 
    {
        bool Add(Account account);
    }

    public class AccountMgr : IAccountMgr
    {
        AccountDacMgr dacMgr;

        public AccountMgr()
        {
            
        }

        public bool Add(Account account)
        {
            bool result = false;

            try
            {
                AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.CACentral1);

                Dictionary<string, AttributeValue> attributes = new Dictionary<string, AttributeValue>();


                attributes["username"] = new AttributeValue { S = account.UserName };
                attributes["password"] = new AttributeValue { S = account.Password };

                PutItemRequest request = new PutItemRequest
                {
                    TableName = "User",
                    Item = attributes
                };

                client.PutItemAsync(request);

                result = true;
            }
            catch
            {

            }

            return result;
        }

        

        //public bool Login()
        //{


        //    return dacMgr.LoginDAC();
        //}


        //public void SetClone(Account account)
        //{


        //    dacMgr.SetClone(account);
        //}
    }
}
