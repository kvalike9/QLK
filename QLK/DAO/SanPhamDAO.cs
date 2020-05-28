﻿using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO _Ins;

        public static SanPhamDAO Ins
        {
            get { if (_Ins == null) _Ins = new SanPhamDAO(); return SanPhamDAO._Ins; }
            private set { SanPhamDAO.Ins = value; }
        }

        private SanPhamDAO() { }

        public List<SanPham> LoadSanPham()
        {
            List<SanPham> sanPhams = new List<SanPham>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowObject");
            foreach (DataRow item in data.Rows)
            {
                SanPham san = new SanPham(item);
                sanPhams.Add(san);
            }
            return sanPhams;
        }
    }
}
