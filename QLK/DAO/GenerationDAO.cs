using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class GenerationDAO
    {
        private static GenerationDAO _Ins;

        public static GenerationDAO Ins
        {
            get { if (_Ins == null) _Ins = new GenerationDAO(); return GenerationDAO._Ins; }
            private set { GenerationDAO.Ins = value; }
        }

        private GenerationDAO() { }

        public List<Generation> LoadColor()
        {
            List<Generation> generations = new List<Generation>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowUnit");
            foreach (DataRow item in data.Rows)
            {
                Generation generation = new Generation(item);
                generations.Add(generation);
            }
            return generations;
        }

        public bool CreateGeneration(string Generation)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_AddGeneration @DisplayName", new object[] { Generation });
            return re > 0;
        }

        public bool UpdateGeneration(int Id, string Generation)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_UpdateGeneration @Id , @DisplayName", new object[] { Id, Generation });
            return re > 0;
        }

        public bool DeleteGeneration(int Id)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_DeleteGeneration @Id", new object[] { Id });
            return re > 0;
        }
    }
}
