using Konger.CoreAngular.DAL;
using Konger.CoreAngular.Model;

namespace Konger.CoreAngular.Logic
{
    public class AccountMgr : Account
    {
        AccountDacMgr dacMgr;

        public AccountMgr()
        {
            dacMgr = new AccountDacMgr();
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



        public bool Login()
        {


            return dacMgr.LoginDAC();
        }


        public void SetClone(Account account)
        {


            dacMgr.SetClone(account);
        }
    }
}
