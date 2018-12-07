using Konger.CoreAngular.DAL;
using Konger.CoreAngular.Model;
using Microsoft.Extensions.Caching.Memory;

namespace Konger.CoreAngular.Logic
{
    public class AccountMgr : Account
    {

        AccountDacMgr dacMgr;

        public AccountMgr(Account _account, IMemoryCache memoryCache)
        {
            dacMgr = new AccountDacMgr(_account, memoryCache);
        }

        public bool Add()
        {
            bool result = false;

            try
            {
                result = dacMgr.InsertUser();
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
