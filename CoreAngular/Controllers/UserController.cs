using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Konger.CoreAngular.Logic;
using Konger.CoreAngular.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAccountMgr AccountMgr { get; }

        public UserController(IAccountMgr accountMgr)
        {
            AccountMgr = accountMgr;
        }

        [HttpPost("[action]")]
        public bool RegisterUser([FromBody]Account account)
        {
            bool success = false;

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

            //success = AccountMgr.Add(account);

            //success = _accountMgr.Add(account);


            return success;
        }
    }
}