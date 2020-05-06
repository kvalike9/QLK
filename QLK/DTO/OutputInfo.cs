using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class OutputInfo
    {
        private string _ID;
        private string _IDObject;
        private string _IDOutput;
        private int _IdCustomer;
        private int _Count;
        private string _Status;

        public OutputInfo(DataRow row)
        {
            this.ID = row["Id"].ToString();
            this.IDObject = row["IdObject"].ToString();
            this.IDOutput = row["IDOutput"].ToString();
            this.IdCustomer = int.Parse(row["IdCustomer"].ToString());
            this.Count = int.Parse(row["Count"].ToString());
            this.Status = row["Status"].ToString();
        }

        public OutputInfo(string ID, string IDObject, string IDOutput, int IdCustomer, int Count, string Status)
        {
            this.ID = ID;
            this.IDObject = IDObject;
            this.IDOutput = IDOutput;
            this.IdCustomer = IdCustomer;
            this.Count = Count;
            this.Status = Status;
        }

        public string ID { get => _ID; set => _ID = value; }
        public string IDObject { get => _IDObject; set => _IDObject = value; }
        public string IDOutput { get => _IDOutput; set => _IDOutput = value; }
        public int IdCustomer { get => _IdCustomer; set => _IdCustomer = value; }
        public int Count { get => _Count; set => _Count = value; }
        public string Status { get => _Status; set => _Status = value; }
    }
}
