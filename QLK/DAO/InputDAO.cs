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

        public List<PhieuNhap> LoadInputInfobyid(string id)
        {
            List<PhieuNhap> inputs = new List<PhieuNhap>();
            DataTable data = ConnectionDAO.Ins.ExecuteQuery("sp_ShowInputInfoByDateId @Day ", new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                PhieuNhap input = new PhieuNhap(item);
                inputs.Add(input);
            }
            return inputs;
        }

        public bool CreateInput(string Ma)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_InputTime @Ma ", new object[] { Ma });
            return re > 0;
        }

        public bool CreateInputInfo(string Ma, string IdObject, string IdInput, int Count, double InputPrice, double OutputPrice, string Status)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_AddInputInfo @Ma , @IdObjedt , @IdInput , @Count , @InputPrice , @OutputPrice , @Status ", new object[] { Ma , IdObject , IdInput , Count , InputPrice , OutputPrice , Status });
            return re > 0;
        }
        public bool DeleteInputInfo(string id)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_DeleteInputInfo @Id ", new object[] { id });
            return re > 0;
        }
        public bool DeleteInputDate(string id)
        {
            int re = ConnectionDAO.Ins.ExecuteNonQuery("sp_DeleteInputDate @Id ", new object[] { id });
            return re > 0;
        }
    }
}
