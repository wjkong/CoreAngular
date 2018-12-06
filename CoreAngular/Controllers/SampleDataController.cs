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
        public SampleDataController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
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

            var userAccount = new Account
            {
                UserName = account.UserName,
                Password = account.Password
            };

            var accountMgr = new AccountMgr(userAccount, _cache);


            success = accountMgr.Add();


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
