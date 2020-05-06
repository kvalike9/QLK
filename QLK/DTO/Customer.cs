using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class Customer
    {
        private int _ID;
        private string _DisplayName;
        private string _Address;
        private string _Phone;
        private string _Email;
        private string _MoreInfo;
        private string _ContractDate;

        public Customer(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DisplayName = row["DisplayName"].ToString();
            this.Address = row["Address"].ToString();
            this.Phone = row["Phone"].ToString();
            this.Email = row["Email"].ToString();
            this.MoreInfo = row["MoreInfo"].ToString();
            this.ContractDate = Convert.ToDateTime(row["ContractDate"].ToString()).ToString("dd/MM/yyyy").ToString();
            //this.ContractDate = ContractDate; Convert.ToDateTime(row["StartOn"].ToString()).ToString("MMM dd").ToString();
        }

        public Customer(int ID, string DisplayName, string Address, string Phone, string Email, string MoreInfo, string ContractDate)
        {
            this.ID = ID;
            this.DisplayName = DisplayName;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.MoreInfo = MoreInfo;
            this.ContractDate = ContractDate;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string MoreInfo { get => _MoreInfo; set => _MoreInfo = value; }
        public string ContractDate { get => _ContractDate; set => _ContractDate = value; }
    }
}
