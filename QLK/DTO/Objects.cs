using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class Objects
    {
        private string _ID;
        private string _DisplayName;
        private int _IDUnit;
        private int _IDSuplier;
        private string _QRCode;
        private string _BarCode;
        private int _IDGenera;
        private int _IDColorAL;

        public Objects(DataRow row)
        {
            this.ID = row["Id"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.IDUnit = int.Parse(row["IdUnit"].ToString());
            this.IDSuplier = int.Parse(row["IdSuplier"].ToString());
            this.QRCode = row["QRCode"].ToString();
            this.BarCode = row["BarCode"].ToString();
            this.IDGenera = int.Parse(row["IdGenera"].ToString());
            this.IDColorAL = int.Parse(row["idColorAL"].ToString());

        }

        public Objects(string ID, string DisplayName, int IDUnit, int IDSuplier, string QRCode, string BarCode, int IDGenera, int IDColorAL)
        {
            this.ID = ID;
            this.DisplayName = DisplayName;
            this.IDUnit = IDUnit;
            this.IDSuplier = IDSuplier;
            this.QRCode = QRCode;
            this.BarCode = BarCode;
            this.IDGenera = IDGenera;
            this.IDColorAL = IDColorAL;
        }

        public string ID { get => _ID; set => _ID = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public int IDUnit { get => _IDUnit; set => _IDUnit = value; }
        public int IDSuplier { get => _IDSuplier; set => _IDSuplier = value; }
        public string QRCode { get => _QRCode; set => _QRCode = value; }
        public string BarCode { get => _BarCode; set => _BarCode = value; }
        public int IDGenera { get => _IDGenera; set => _IDGenera = value; }
        public int IDColorAL { get => _IDColorAL; set => _IDColorAL = value; }
    }
}
