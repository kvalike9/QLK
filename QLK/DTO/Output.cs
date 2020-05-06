using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class Output
    {
        private int _ID;
        private string _DateOutput;

        public Output(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DateOutput = Convert.ToDateTime(row["DateOutput"].ToString()).ToString("dd/MM/yyyy").ToString();
        }

        public Output(int ID, string DateOutput)
        {
            this.ID = ID;
            this.DateOutput = DateOutput;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DateOutput { get => _DateOutput; set => _DateOutput = value; }
    }
}
