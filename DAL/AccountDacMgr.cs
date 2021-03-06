﻿using Konger.CoreAngular.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Data.SqlClient;

namespace Konger.CoreAngular.DAL
{
    public class AccountDacMgr : DataAccessBase
    {
        private Account account;

        public AccountDacMgr(Account _account, IMemoryCache memoryCache) : base(memoryCache)
        {
            account = _account;
        }

        public bool InsertUser()
        {
            var success = false;

            using (var connection = this.CreateConnection())
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"INSERT INTO [User] (Username, Password) VALUES (@Username, @Password)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.AddWithValue("@UserName", account.UserName);
                    cmd.Parameters.AddWithValue("@Password", account.Password);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    success = true;
                }
            }

            return success;
        }

        //public bool LoginDAC()
        //{
        //    var flag = false;

        //    using (var connection = SQLHelper.GetConnection())
        //    {
        //        using (var cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = @"SELECT * FROM [User] WHERE UserName = @UserName AND Password = @Password";
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = connection;
        //            cmd.Parameters.AddWithValue("@Password", Password);
        //            cmd.Parameters.AddWithValue("@UserName", UserName);


        //            if (cmd.Connection.State == ConnectionState.Closed)
        //            {
        //                cmd.Connection.Open();
        //            }

        //            using (var dreader = cmd.ExecuteReader())
        //            {
        //                flag |= dreader.Read();
        //            }
        //        }
        //    }

        //    return flag;
        //}

    }
}
