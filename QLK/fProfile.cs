﻿using Bunifu.UI.WinForms.BunifuButton;
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
    public partial class fProfile : Form
    {
        //private User loginUser;

        //public User LoginUser {
        //    get  { return loginUser; }
        //    set { loginUser = value; }
        //}

        public fProfile(User user)
        {
            InitializeComponent();
            lbDisplayName.Text = "Hello "+user.DisplayName;
        }

        private void fProfile_Load(object sender, EventArgs e)
        {
            addControlDock();
            //ChartRender();
            TonKhoChart();
            dtgvTonKho.DataSource = TonKhoDAO.Ins.LoadTonKho();
            LoadNhapXuatNgay();
            LoadSanPham();
        }
        
        //private void ChartRender()
        //{
        //    Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
        //    Bunifu.DataViz.WinForms.DataPoint dataPoint = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
        //    Random random = new Random();
        //    for (int i = 0; i < 20; i++)
        //    {
        //        //dataPoint.addxy("new Date (2020, 4, "+i+")", random.Next(1, 100));
        //        dataPoint.addxy("new Date (2020, 10, " + i + ")", random.Next(1, 100));
        //    }
        //    canvas.addData(dataPoint);
        //    chart.Render(canvas);
        //}

        private void TonKhoChart()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(39, 240, 157));
            colors.Add(Color.FromArgb(11, 180, 225));
            colors.Add(Color.FromArgb(255, 178, 53));
            colors.Add(Color.LavenderBlush);
            DataTable data = new DataTable();
            data = TonKhoDAO.Ins.TonKhoChart();
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint dataPoint = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            Bunifu.DataViz.WinForms.DataPoint dataPoint2 = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            Bunifu.DataViz.WinForms.DataPoint dataPoint3 = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            int i = 0;
            foreach (DataRow row in data.Rows)
            {
                dataPoint.addLabely(row["TenHang"].ToString(), row["TongNhap"].ToString());
                dataPoint2.addLabely(row["TenHang"].ToString(), row["TongXuat"].ToString());
                dataPoint3.addLabely(row["TenHang"].ToString(), row["Ton"].ToString());
                //MessageBox.Show(row["Ton"].ToString());
                i += 250;
                chart.Width = i;
            }
            canvas.addData(dataPoint);
            canvas.addData(dataPoint2);
            canvas.addData(dataPoint3);
            chart.colorSet.AddRange(colors);
            chart.Render(canvas);
            
        }

        private void addControlDock()
        {
            DockControl.SubscribeControlsToDragEvents(new Control[] {
                bunifuGradientPanel1,
                panelLeft,
                bunifuGradientPanel1,
                bunifuPages1,
                tabPage1,
                tabPage2
            }, false);
        }
        //button set Page start
        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeSprtr(sender, e);
            //MessageBox.Show("CLick me!");
            bunifuPages1.SetPage(0);
            LoadNhapXuatNgay();
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            ChangeSprtr(sender, e);
            bunifuPages1.SetPage(3);
            lbInputTile.Text = "Danh sách phiếu nhập ngày: " + dtpkInput.Value.ToString("dd/MM/yyyy");
            LoadInputByDay();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            ChangeSprtr(sender, e);
            bunifuPages1.SetPage(4);
            lbOutputTile.Text = ("Danh sách tất cả phiếu xuất");
            LoadOutput();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            ChangeSprtr(sender, e);
            bunifuPages1.SetPage(1);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            ChangeSprtr(sender, e);
            bunifuPages1.SetPage(2);
            TonKhoChart();
            LoadDDAll();
        }
        //button set pgae end
        private void ChangeSprtr(object sender, EventArgs e)
        {
            Sprtr.Height = ((BunifuButton)sender).Height - 4;
            Sprtr.Top = ((BunifuButton)sender).Top + 2;
        }
        //Load All item Start
        private DataGridViewButtonColumn addButtonDataGrid(string name)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = name;
            btn.Name = "button";
            btn.Text = name;
            btn.UseColumnTextForButtonValue = true;
            return btn;
        }
        private void LoadDDAll()
        {
            ddUnit.DataSource = UnitDAO.Ins.LoadUnit();
            ddUnit.DisplayMember = "DisplayName";
            ddUnit.ValueMember = "Id";
            ddSupplier.DataSource = SupplierDAO.Ins.LoadSupplier();
            ddSupplier.DisplayMember = "DisplayName";
            ddSupplier.ValueMember = "Id";
            ddGenera.DataSource = GenerationDAO.Ins.LoadGeneration();
            ddGenera.DisplayMember = "DisplayName";
            ddGenera.ValueMember = "Id";
            ddColor.DataSource = ColorALDAO.Ins.LoadColor();
            ddColor.DisplayMember = "DisplayName";
            ddColor.ValueMember = "Id";
        }
        private void LoadNhapXuatNgay()
        {
            DataTable data = new DataTable();
            //data = TonKhoDAO.Ins.LoadNhapXuatNgay(dtpkDate.Value.ToString("yyyy/MM/dd"));
            string Day = dtpkDate.Value.ToString("yyyy/MM/dd");
            data = TonKhoDAO.Ins.LoadNhapXuatNgay(Day);
            int TongNhap = 0, TongXuat = 0;
            foreach (DataRow row in data.Rows)
            {
                //TongNhap = int.TryParse(row["TongNhap"].ToString(),out TongNhap);
                //TongXuat = int.Parse(row["TongXuat"].ToString());
                int number;

                bool CheckNumberNhap = Int32.TryParse(row["TongNhap"].ToString(), out number);
                if (CheckNumberNhap)
                {
                    TongNhap = number;
                }
                bool CheckNumberXuat = Int32.TryParse(row["TongXuat"].ToString(), out number);
                if (CheckNumberNhap)
                {
                    TongXuat = number;
                }

            }
            LBNhap.Text = "Nhập: " + TongNhap;
            LBXuat.Text = "Xuất: " + TongXuat;
        }

        private void LoadSanPham()
        {
            try
            {
                dtgvObject.DataSource = SanPhamDAO.Ins.LoadSanPham();
            }
            catch
            {

                throw;
            }
        }

        private void LoadInput()
        {
            dtgvInput.Columns.Clear();
            dtgvInput.DataSource = InputDAO.Ins.LoadInput();
            dtgvInput.Columns.Add(addButtonDataGrid("Edit"));
            dtgvInput.Columns.Add(addButtonDataGrid("Delete"));
        }

        private void LoadInputByDay()
        {
            dtgvInput.Columns.Clear();
            dtgvInput.DataSource = InputDAO.Ins.LoadInputByDay(dtpkInput.Value.ToString("yyyy-MM-dd"));
            dtgvInput.Columns.Add(addButtonDataGrid("Edit"));
            dtgvInput.Columns.Add(addButtonDataGrid("Delete"));
        }

        private void LoadOutput()
        {
            dtgvOutput.Columns.Clear();
            dtgvOutput.DataSource = OutputDAO.Ins.LoadOutput();
            dtgvOutput.Columns.Add(addButtonDataGrid("Edit"));
            dtgvOutput.Columns.Add(addButtonDataGrid("Delete"));
        }
        //Load all item end

        private void btnshowhide_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(panelLeft, false);
            if (panelLeft.Width > 70)
            {
                panelLeft.Width = 70;
            }
            else
            {
                panelLeft.Width = 200;
            }
            bunifuTransition1.ShowSync(panelLeft, false);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.No;    
            this.Close();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            fAddEditDelete f = new fAddEditDelete();
            f.ShowDialog();
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNhapXuatNgay();
        }

        private void btnSanPhamAdd_Click(object sender, EventArgs e)
        {
            if (SanPhamDAO.Ins.CreateSanPham("SP", txtNameSanPham.Text, int.Parse(ddUnit.SelectedValue.ToString()), int.Parse(ddSupplier.SelectedValue.ToString()), int.Parse(ddGenera.SelectedValue.ToString()), int.Parse(ddColor.SelectedValue.ToString())))
            {
                MessageBox.Show("Tạo thành công");
                LoadSanPham();
            }
            else
            {
                MessageBox.Show("Chắc có lỗi gì đó :V");
            }
        }

        private void btnInputShow_Click(object sender, EventArgs e)
        {
            lbInputTile.Text = "Danh sách phiếu nhập ngày: " + dtpkInput.Value.ToString("dd/MM/yyyy");
            LoadInputByDay();
        }

        private void btnInputShowAll_Click(object sender, EventArgs e)
        {
            lbInputTile.Text = "Danh sách tất cả phiếu nhập";
            LoadInput();
        }

        private void btnInputAdd_Click(object sender, EventArgs e)
        {
            if (InputDAO.Ins.CreateInput("DA"))
            {
                MessageBox.Show("Tạo thành công");
            }
            else
            {
                MessageBox.Show("Lỗi kết nối :v");
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            fAddEditDelete f = new fAddEditDelete();
            f.ShowDialog();
        }

        private void dtgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                string id = dtgvInput.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                string dateinput = dtgvInput.Rows[e.RowIndex].Cells["DateInput"].Value.ToString();
                fMoreInfo f = new fMoreInfo(id, dateinput);
                f.ShowDialog();
            }
            if (e.RowIndex != -1 && e.ColumnIndex == 3)
            {
                string mess = dtgvInput.Rows[e.RowIndex].Cells["DateInput"].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \"" + mess + "\"", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string Id = dtgvInput.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    try
                    {
                        if (InputDAO.Ins.DeleteInputDate(Id))
                        {
                            LoadInputByDay();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Phiếu nhập này không thể xóa");
                    }

                }
            }

        }
    }
}
