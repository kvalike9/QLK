using QLK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DAO
{
    public class InputDAO
    {
        private static InputDAO _Ins;

        public static InputDAO Ins
        {
            get { if (_Ins == null) _Ins = new InputDAO(); return InputDAO._Ins; }
            private set { InputDAO.Ins = value; }
        }

        private InputDAO() { }

        public List<Input> LoadInput()
        {
            List<Input> inputs = new List<Input>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowInput");
            foreach (DataRow item in data.Rows)
            {
                Input input = new Input(item);
                inputs.Add(input);
            }
            return inputs;
        }

        public List<Input> LoadInputByDay(string Day)
        {
            List<Input> inputs = new List<Input>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowInputByDay @Day ", new object[] { Day });
            foreach (DataRow item in data.Rows)
            {
                Input input = new Input(item);
                inputs.Add(input);
            }
            return inputs;
        }

        public bool CreateInput(string Ma)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_InputTime @Ma ", new object[] { Ma });
            return re > 0;
        }
    }
}
