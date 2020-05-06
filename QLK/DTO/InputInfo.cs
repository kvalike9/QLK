using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class InputInfo
    {
        private string _ID;
        private string _IDObject;
        private string _IDInput;
        private int _Count;
        private double _InputPrice;
        private double _OutputPrice;
        private string _Status;

        public InputInfo(DataRow row)
        {
            this.ID = row["Id"].ToString();
            this.IDObject = row["IdObject"].ToString();
            this.IDInput = row["IdInput"].ToString();
            this.Count = int.Parse(row["Count"].ToString());
            this.InputPrice = double.Parse(row["InputPrice"].ToString());
            this.OutputPrice = double.Parse(row["OutputPrice"].ToString());
            this.Status = row["Status"].ToString();
        }

        public InputInfo(string ID, string IDObject, string IDInput, int Count, double InputPrice, double OutputPrice, string Status)
        {
            this.ID = ID;
            this.IDObject = IDObject;
            this.IDInput = IDInput;
            this.Count = Count;
            this.InputPrice = InputPrice;
            this.OutputPrice = OutputPrice;
            this.Status = Status;
        }

        public string ID { get => _ID; set => _ID = value; }
        public string IDObject { get => _IDObject; set => _IDObject = value; }
        public string IDInput { get => _IDInput; set => _IDInput = value; }
        public int Count { get => _Count; set => _Count = value; }
        public double InputPrice { get => _InputPrice; set => _InputPrice = value; }
        public double OutputPrice { get => _OutputPrice; set => _OutputPrice = value; }
        public string Status { get => _Status; set => _Status = value; }
    }
}
