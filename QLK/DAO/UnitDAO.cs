using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class UnitDAO
    {
        private static UnitDAO _Ins;

        public static UnitDAO Ins
        {
            get { if (_Ins == null) _Ins = new UnitDAO(); return UnitDAO._Ins; }
            private set { UnitDAO.Ins = value; }
        }

        private UnitDAO() { }

        public List<Unit> LoadUnit()
        {
            List<Unit> units = new List<Unit>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowUnit");
            foreach (DataRow item in data.Rows)
            {
                Unit unit = new Unit(item);
                units.Add(unit);
            }
            return units;
        }

        public bool CreateUnit(string Unit)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_AddUnit @DisplayName", new object[] { Unit });
            return re > 0;
        }

        public bool UpdateUnit(int Id, string Unit)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_UpdateUnit @Id , @DisplayName", new object[] { Id, Unit });
            return re > 0;
        }

        public bool DeleteUnit(int Id)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_DeleteUnit @Id", new object[] { Id });
            return re > 0;
        }
    }
}
