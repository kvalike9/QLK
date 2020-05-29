using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class PhieuNhap
    {
        private string _IdSanPham;
        private string _DisplayName;
        private double _InputPrice;
        private double _OutputPrice;
        private int _Count;
        private string _Status;

        public PhieuNhap(DataRow row)
        {
            this.IdSanPham = row["IdSanPham"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.InputPrice = double.Parse(row["InputPrice"].ToString());
            this.OutputPrice = double.Parse(row["OutputPrice"].ToString());
            this.Count = int.Parse(row["Count"].ToString());
            this.Status = row["Status"].ToString();
        }

        public PhieuNhap(string IdSanPham, string DisplayName, double InputPrice, double OutputPrice, int Count, string Status)
        {
            this.IdSanPham = IdSanPham;
            this.DisplayName = DisplayName;
            this.InputPrice = InputPrice;
            this.OutputPrice = OutputPrice;
            this.Count = Count;
            this.Status = Status;
        }

        public string IdSanPham { get => _IdSanPham; set => _IdSanPham = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
        public double InputPrice { get => _InputPrice; set => _InputPrice = value; }
        public double OutputPrice { get => _OutputPrice; set => _OutputPrice = value; }
        public int Count { get => _Count; set => _Count = value; }
        public string Status { get => _Status; set => _Status = value; }
    }
}
