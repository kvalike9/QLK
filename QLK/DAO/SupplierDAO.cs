using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class SupplierDAO
    {
        private static SupplierDAO _Ins;

        public static SupplierDAO Ins
        {
            get { if (_Ins == null) _Ins = new SupplierDAO(); return SupplierDAO._Ins; }
            private set { SupplierDAO.Ins = value; }
        }

        private SupplierDAO() { }

        public List<Supplier> LoadSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowSupplier");
            foreach (DataRow item in data.Rows)
            {
                Supplier supplier = new Supplier(item);
                suppliers.Add(supplier);
            }
            return suppliers;
        }

        public bool CreateSuppler(string Name, string Address, string Phone, string Email, string MoreInfo, string ContractDate)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_AddSupplier @DisplayName , @Address , @Phone , @Email , @MoreInfo , @ContractDate", new object[] { Name, Address, Phone, Email, MoreInfo, ContractDate });
            return re > 0;
        }
    }
}
