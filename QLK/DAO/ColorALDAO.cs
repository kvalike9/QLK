using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class ColorALDAO
    {
        private static ColorALDAO _Ins;

        public static ColorALDAO Ins
        {
            get { if (_Ins == null) _Ins = new ColorALDAO(); return ColorALDAO._Ins; }
            private set { ColorALDAO.Ins = value; }
        }

        private ColorALDAO() { }

        public List<ColorAL> LoadColor()
        {
            List<ColorAL> colors = new List<ColorAL>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowUnit");
            foreach (DataRow item in data.Rows)
            {
                ColorAL color = new ColorAL(item);
                colors.Add(color);
            }
            return colors;
        }

        public bool CreateColor(string Color)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_AddColor @DisplayName", new object[] { Color });
            return re > 0;
        }

        public bool UpdateColor(int Id, string Color)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_UpdateColor @Id , @DisplayName", new object[] { Id, Color });
            return re > 0;
        }

        public bool DeleteColor(int Id)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_DeleteColor @Id", new object[] { Id });
            return re > 0;
        }
    }
}
