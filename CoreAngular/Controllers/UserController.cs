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


        //[HttpGet]
        //public async Task<IActionResult> GetUser([FromQuery] string username)
        //{
        //    //var response = await AccountMgr;
        //    AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.CACentral1);

        //    return Ok(response);
        //}

        [HttpPost("[action]")]
        public bool RegisterUser([FromBody]Account account)
        {
            bool success = false;

            success = AccountMgr.Add(account);

            return success;
        }
    }
}