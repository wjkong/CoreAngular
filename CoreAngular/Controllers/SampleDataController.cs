using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Konger.CoreAngular.Logic;
using Konger.CoreAngular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreAngular.Controllers
{


    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private IMemoryCache _cache;
        private IAccountMgr _accountMgr;

        public SampleDataController(IMemoryCache memoryCache, IAccountMgr accountMgr)
        {
            _cache = memoryCache;
            _accountMgr = accountMgr;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            //AmazonDynamoDBClient client = new AmazonDynamoDBClient(RegionEndpoint.CACentral1);
            //Table table = Table.LoadTable(client, "Product");

            //var document = table.GetItemAsync(;

            //var deal = new Document();
            //deal["ProductId"] = "1111133";
            //deal["Name"] = "Stove";

            //table.PutItemAsync(deal);

            
            //Dictionary<string, AttributeValue> attributes = new Dictionary<string, AttributeValue>();


            //attributes["Date"] = new AttributeValue { S = "12/31/2019" };
            //attributes["Amount"] = new AttributeValue { S = "193300" };

            //PutItemRequest request = new PutItemRequest
            //{
            //    TableName = "RRSP",
            //    Item = attributes
            //};

            //client.PutItemAsync(request);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpPost("[action]")]
        public bool RegisterUser([FromBody]Account account)
        {
            bool success = false;

            //var userAccount = new Account
            //{
            //    UserName = account.UserName,
            //    Password = account.Password
            //};

            
            //var accountMgr = new AccountMgr(userAccount, _cache);


            success = _accountMgr.Add(account);


            return success;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
