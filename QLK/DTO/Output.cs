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
        private string _ID;
        private string _DateOutput;

        public Output(DataRow row)
        {
            this.ID = row["Id"].ToString();
            this.DateOutput = Convert.ToDateTime(row["DateOutput"].ToString()).ToString("dd/MM/yyyy hh:mm:ss tt").ToString();
        }

        public Output(string ID, string DateOutput)
        {
            this.ID = ID;
            this.DateOutput = DateOutput;
        }

        public string ID { get => _ID; set => _ID = value; }
        public string DateOutput { get => _DateOutput; set => _DateOutput = value; }
    }
}
