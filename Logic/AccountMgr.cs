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
            //var dacMgr = ServiceLocator.Current.GetInstance<IAccountDacMgr>();

            return dacMgr.InsertUser();
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
