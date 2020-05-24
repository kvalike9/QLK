using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class TonKho
    {
        private string _MaHang;
        private string _TenHang;
        private int _TongNhap;
        private int _TongXuat;
        private int _Ton;


        public TonKho(DataRow row)
        {
            this.MaHang = row["MaHang"].ToString();
            this.TenHang = row["TenHang"].ToString();
            this.TongNhap = int.Parse(row["TongNhap"].ToString());
            this.TongXuat = int.Parse(row["TongXuat"].ToString());
            this.Ton = int.Parse(row["Ton"].ToString());
        }

        public TonKho(string MaHang, string TenHang, int TongNhap, int _TongXuat, int Ton)
        {
            this.MaHang = MaHang;
            this.TenHang = TenHang;
            this.TongNhap = TongNhap;
            this.TongXuat = TongXuat;
            this.Ton = Ton;
        }

        public string MaHang { get => _MaHang; set => _MaHang = value; }
        public string TenHang { get => _TenHang; set => _TenHang = value; }
        public int TongNhap { get => _TongNhap; set => _TongNhap = value; }
        public int TongXuat { get => _TongXuat; set => _TongXuat = value; }
        public int Ton { get => _Ton; set => _Ton = value; }
    }
}
