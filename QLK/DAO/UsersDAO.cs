using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class UsersDAO
    {
        private static UsersDAO _Ins;

        public static UsersDAO Ins
        {
            get { if (_Ins == null) _Ins = new UsersDAO(); return UsersDAO._Ins; }
            private set { UsersDAO.Ins = value; }
        }

        private UsersDAO() { }

        public List<Users> LoadUsers()
        {
            List<Users> users = new List<Users>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowUser");
            foreach (DataRow item in data.Rows)
            {
                Users user = new Users(item);
                users.Add(user);
            }
            return users;
        }
    }
}
