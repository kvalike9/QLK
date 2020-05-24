using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class TonKhoDAO
    {
        private static TonKhoDAO _Ins;

        public static TonKhoDAO Ins
        {
            get { if (_Ins == null) _Ins = new TonKhoDAO(); return TonKhoDAO._Ins; }
            private set { TonKhoDAO._Ins = value; }
        }
        private TonKhoDAO() { }

        public DataTable TonKhoChart()
        {
            DataTable re = ConnectionDAO.Ins.ExecuteQuery("sp_ShowTonKho ");
            return re;
        }
        public List<TonKho> LoadTonKho()
        {
            List<TonKho> tonKhos = new List<TonKho>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowTonKho");
            foreach (DataRow item in data.Rows)
            {
                TonKho ton = new TonKho(item);
                tonKhos.Add(ton);
            }
            return tonKhos;
        }
    }
}
