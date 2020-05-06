using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class UserDAO
    {
        private static UserDAO _Ins;

        public static UserDAO Ins
        {
            get { if (_Ins == null) _Ins = new UserDAO(); return UserDAO._Ins; }
            private set { UserDAO.Ins = value; }
        }
        private UserDAO() { }

        public bool CreateUser(string Name, string Username, string Password)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_CreateUser @Name , @User , @Pass", new object[] { Name, Username, Password });
            return re > 0;
        }
        public bool CheckUsername(string Username)
        {
            DataTable re = ConnectionDAO.Ins.ExecuteQuery("sp_CheckUserName @UserName", new object[] { Username });
            return re.Rows.Count > 0;
        }
        public bool CheckUsernamePassword(string Username, string Password)
        {
            DataTable re = ConnectionDAO.Ins.ExecuteQuery("sp_CheckUserNamePassword @UserName , @Password", new object[] { Username, Password });
            return re.Rows.Count > 0;
        }
        public User GetAccountByUserName(string userName)
        {
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("Select * from Users where UserName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new User(item);
            }

            return null;
        }
    }
}
