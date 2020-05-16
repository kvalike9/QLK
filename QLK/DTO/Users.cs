using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class Users
    {
        private int _ID;
        private string _DisplayName;
        private string _Username;
        private string _Roles;
        private int _Idr;

        public Users(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DisplayName = row["DisplayName"].ToString();
            this.Username = row["UserName"].ToString();
            this.Roles = row["Roles"].ToString();
            this.Idr = int.Parse(row["Idr"].ToString());
        }

        public Users(int ID, string DisplayName, string Username, string Roles, int Idr)
        {
            this.ID = ID;
            this.DisplayName = DisplayName;
            this.Username = Username;
            this.Roles = Roles;
            this.Idr = Idr;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Roles { get => _Roles; set => _Roles = value; }
        public int Idr { get => _Idr; set => _Idr = value; }
    }
}
