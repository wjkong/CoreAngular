using Konger.CoreAngular.DAL;
using Konger.CoreAngular.Model;
using Microsoft.Extensions.Caching.Memory;

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
