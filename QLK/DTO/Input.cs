using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class Input
    {
        private int _ID;
        private string _DateInput;

        public Input(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DateInput = Convert.ToDateTime(row["DateInput"].ToString()).ToString("dd/MM/yyyy").ToString();
        }

        public Input(int ID, string DateInput)
        {
            this.ID = ID;
            this.DateInput = DateInput;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DateInput { get => _DateInput; set => _DateInput = value; }
    }
}
