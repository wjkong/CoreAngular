using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            success = AccountMgr.Add(account);

            //success = _accountMgr.Add(account);


            return success;
        }
    }
}