using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class NhapXuat
    {
        private int _TongNhap;
        private int _TongXuat;

        public NhapXuat(DataRow row)
        {
            this.TongNhap = int.Parse(row["TongNhap"].ToString());
            this.TongXuat = int.Parse(row["TongXuat"].ToString());
        }

        public NhapXuat(int TongNhap, int TongXuat)
        {
            this.TongNhap = TongNhap;
            this.TongXuat = TongXuat;
        }

        public int TongNhap { get => _TongNhap; set => _TongNhap = value; }
        public int TongXuat { get => _TongXuat; set => _TongXuat = value; }
    }
}
