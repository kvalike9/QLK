using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO _Ins;

        public static CustomerDAO Ins
        {
            get { if (_Ins == null) _Ins = new CustomerDAO(); return CustomerDAO._Ins; }
            private set { CustomerDAO.Ins = value; }
        }

        private CustomerDAO() { }

        public List<Customer> LoadCustomer()
        {
            List<Customer> customers = new List<Customer>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowCustomer");
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                customers.Add(customer);
            }
            return customers;
        }

        public bool CreateCustomer(string Name, string Address, string Phone, string Email, string MoreInfo, string ContractDate)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_AddCustomer @DisplayName , @Address , @Phone , @Email , @MoreInfo , @ContractDate", new object[] { Name, Address, Phone, Email, MoreInfo, ContractDate });
            return re > 0;
        }

        public bool UpdateCustomer(int Id, string Name, string Address, string Phone, string Email, string MoreInfo, string ContractDate)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_UpdateCustomer @Id , @DisplayName , @Address , @Phone , @Email , @MoreInfo , @ContractDate", new object[] { Id, Name, Address, Phone, Email, MoreInfo, ContractDate });
            return re > 0;
        }

        public bool DeleteCustomer(int Id)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_DeleteCustomer @Id", new object[] { Id });
            return re > 0;
        }
    }
}
