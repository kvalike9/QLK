using QLK.DAO;
using QLK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    public partial class fMoreInfo : Form
    {
        string idphieu;
        public fMoreInfo(string IdPhieuNhap, string ThoiGian)
        {
            InitializeComponent();
            LoadPhieuNhap(IdPhieuNhap);
            LoadDDSanPham();
            lbID.Text = "#"+IdPhieuNhap;
            lbDate.Text = ThoiGian;
            addControlDock();
            idphieu = IdPhieuNhap;
        }

        private void addControlDock()
        {
            DockControl.SubscribeControlsToDragEvents(new Control[] {
                bunifuGradientPanel4,
                txtCount,txtnputPrice,txtOutputPrice,txtStatus,dtgvInputInfo,btnInputInfoAdd
            }, false);
        }

        private void LoadDDSanPham()
        {
            ddSanPham.DataSource = SanPhamDAO.Ins.LoadSanPham();
            ddSanPham.DisplayMember = "DisplayName";
            ddSanPham.ValueMember = "Id";
        }

        private void LoadPhieuNhap(string id)
        {
            dtgvInputInfo.DataSource = InputDAO.Ins.LoadInputInfobyid(id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInputInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputDAO.Ins.CreateInputInfo("IN",ddSanPham.SelectedValue.ToString(),idphieu,int.Parse(txtCount.Text), double.Parse(txtnputPrice.Text), double.Parse(txtOutputPrice.Text),txtStatus.Text))
                {
                    LoadPhieuNhap(idphieu);
                }
                else
                {
                    MessageBox.Show("Lỗi nè !!!");
                }
            }
            catch
            {

                MessageBox.Show("Dev chưa có thời gian fix lỗi, vui lòng nhập số :V");
            }
        }
    }
}
