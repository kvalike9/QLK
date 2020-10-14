using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class OutputDAO
    {
        private static OutputDAO _Ins;

        public static OutputDAO Ins
        {
            get { if (_Ins == null) _Ins = new OutputDAO(); return OutputDAO._Ins; }
            private set { OutputDAO.Ins = value; }
        }

        private OutputDAO() { }

        public List<Output> LoadOutput()
        {
            List<Output> inputs = new List<Output>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowOutput");
            foreach (DataRow item in data.Rows)
            {
                Output input = new Output(item);
                inputs.Add(input);
            }
            return inputs;
        }
    }
}
