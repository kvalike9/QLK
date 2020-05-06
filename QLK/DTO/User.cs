using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class User
    {
        private int _ID;
        private string _DisplayName;
        private string _Username;
        private string _Password;

        public User(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DisplayName = row["DisplayName"].ToString();
            this.Username = row["UserName"].ToString();
            this.Password = row["Password"].ToString();
        }
        public User(int id, string name, string username, string password)
        {
            this.ID = id;
            this.DisplayName = name;
            this.Username = username;
            this.Password = password;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public string Username { get => _Username; set => _Username = value; }
        public string Password { get => _Password; set => _Password = value; }
    }
}
