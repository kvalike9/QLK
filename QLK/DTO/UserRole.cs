using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class UserRole
    {
        private int _ID;
        private string _DisplayName;

        public UserRole(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DisplayName = row["DisplayName"].ToString();
        }

        public UserRole(int ID, string DisplayName)
        {
            this.ID = ID;
            this.DisplayName = DisplayName;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
    }
}
