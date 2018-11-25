
using System.Reflection;


namespace Konger.CoreAngular.Model
{


    public class Account
    {
        //[Required]
        //[Display(Name = "Email")]
        //[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public string UserName { get; set; }

        //[Required]
        //[StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public Account()
        {


        }

        public Account(Account info)
        {
            Clone(info);
        }

        protected void Clone(Account info)
        {
            foreach (PropertyInfo property in base.GetType().GetProperties())
            {
                property.SetValue(this, property.GetValue(info, null), null);
            }
        }
    }
}
