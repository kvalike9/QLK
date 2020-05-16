using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class UserRolesDAO
    {
        private static UserRolesDAO _Ins;

        public static UserRolesDAO Ins
        {
            get { if (_Ins == null) _Ins = new UserRolesDAO(); return UserRolesDAO._Ins; }
            private set { UserRolesDAO.Ins = value; }
        }

        private UserRolesDAO() { }

        public List<UserRoles> LoadUserRoles()
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowUserRole");
            foreach (DataRow item in data.Rows)
            {
                UserRoles user = new UserRoles(item);
                userRoles.Add(user);
            }
            return userRoles;
        }
    }
}
