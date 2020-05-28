using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class SanPham
    {
        private string _Id;
        private string _DisplayName;
        private string _Unit;
        private string _Suplier;
        private string _Genera;
        private string _Color;

        public SanPham(DataRow row)
        {
            this.Id = row["Id"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Suplier = row["Suplier"].ToString();
            this.Genera = row["Genera"].ToString();
            this.Color = row["Color"].ToString();
        }

        public SanPham(string Id, string DisplayName, string Unit, string Suplier, string Genera, string Color)
        {
            this.Id = Id;
            this.DisplayName = DisplayName;
            this.Unit = Unit;
            this.Suplier = Suplier;
            this.Genera = Genera;
            this.Color = Color;
        }

        public string Id { get => _Id; set => _Id = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public string Suplier { get => _Suplier; set => _Suplier = value; }
        public string Genera { get => _Genera; set => _Genera = value; }
        public string Color { get => _Color; set => _Color = value; }
        public string Unit { get => _Unit; set => _Unit = value; }
        
    }
}
