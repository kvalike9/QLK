using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using QLK.DAO;
using QLK.VALIDATOR;
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
    public partial class fAddEditDelete : Form
    {
        public fAddEditDelete()
        {
            InitializeComponent();
        }

        private void fAddEditDelete_Load(object sender, EventArgs e)
        {
            addControlDock();
            txtUnitId.Visible = false;
            LoadUnit();
            LoadSupplier();
        }

        private void LoadSupplier()
        {
            dtgvSupplier.Columns.Clear();
            dtgvSupplier.DataSource = SupplierDAO.Ins.LoadSupplier();
            dtgvSupplier.Columns[0].HeaderText = "Id";
            dtgvSupplier.Columns[1].HeaderText = "Tên NCC";
            dtgvSupplier.Columns[2].HeaderText = "Địa chỉ";
            dtgvSupplier.Columns[3].HeaderText = "SĐT";
            dtgvSupplier.Columns[4].HeaderText = "Email";
            dtgvSupplier.Columns[5].HeaderText = "Thông tin";
            dtgvSupplier.Columns[6].HeaderText = "Ngày hợp tác";

            dtgvSupplier.Columns.Add(addButtonDataGrid("Edit"));
            dtgvSupplier.Columns.Add(addButtonDataGrid("Delete"));
        }

        private void LoadUnit()
        {
            dtgvUnit.Columns.Clear();
            dtgvUnit.DataSource = UnitDAO.Ins.LoadUnit();
            dtgvUnit.Columns[0].HeaderText = "Id";
            dtgvUnit.Columns[0].Width = 50;
            dtgvUnit.Columns[1].HeaderText = "Tên đơn vị";
            dtgvUnit.Columns.Add(addButtonDataGrid("Edit"));
            dtgvUnit.Columns.Add(addButtonDataGrid("Delete"));
            dtgvUnit.Columns[2].Width = 40;
            dtgvUnit.Columns[3].Width = 60;
        }

        private DataGridViewButtonColumn addButtonDataGrid(string name)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = name;
            btn.Name = "button";
            btn.Text = name;
            btn.UseColumnTextForButtonValue = true;
            return btn;
        }

        private void addControlDock()
        {
            bunifuFormDock1.SubscribeControlsToDragEvents(new Control[] {
                pnTop,
                bunifuGradientPanel1,
                tabUnit,
                tabColor,
                bunifuSeparator1,
                pnUnit,
                pcUnit,
                lbUnit
            }, false);
        }
        
        public Image getValidatorImage(bool Valid)
        {
            if (Valid)
            {
                return imageListCheck.Images[0];
            }
            return imageListCheck.Images[1];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            PageAddEditDelete.SetPage(0);
            LoadUnit();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            PageAddEditDelete.SetPage(1);
        }

        private void btnGeneration_Click(object sender, EventArgs e)
        {
            PageAddEditDelete.SetPage(2);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            PageAddEditDelete.SetPage(3);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            PageAddEditDelete.SetPage(4);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            PageAddEditDelete.SetPage(5);
        }

        private void dtgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                //MessageBox.Show(dtgvUnit.Rows[e.RowIndex].Cells[0].Value.ToString());
                lbUnit.Text = "Edit Unit";
                btnAddUnit.Text = "Sửa";
                txtUnit.DataBindings.Clear();
                txtUnitId.DataBindings.Clear();
                txtUnit.DataBindings.Add(new Binding("Text", dtgvUnit.DataSource, "Displayname",true,DataSourceUpdateMode.OnPropertyChanged));
                txtUnitId.DataBindings.Add(new Binding("Text", dtgvUnit.DataSource, "Id",true,DataSourceUpdateMode.OnPropertyChanged));
            }
            if (e.RowIndex != -1 && e.ColumnIndex == 3)
            {
                string mess = dtgvUnit.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \""+ mess +"\"", "Delete", MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    int IdUnit = int.Parse(dtgvUnit.Rows[e.RowIndex].Cells[0].Value.ToString());
                    try
                    {
                        if (UnitDAO.Ins.DeleteUnit(IdUnit))
                        {
                            LoadUnit();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đơn vị này đang được sử dụng không thể xóa");
                    }
                   
                }
            }

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            txtUnit.IconRight = getValidatorImage(Validator.isValidUnit(txtUnit.Text));
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtUnit.Text) && btnAddUnit.Text == "Thêm")
            {
                if (UnitDAO.Ins.CreateUnit(txtUnit.Text))
                {
                    MessageBox.Show("Tạo thành công");
                    LoadUnit();
                }
                else
                {
                    MessageBox.Show("Đơn vị này đã được tạo");
                }
            }
            if (Validator.isValidUnit(txtUnit.Text) && btnAddUnit.Text == "Sửa")
            {
                if (UnitDAO.Ins.UpdateUnit(int.Parse(txtUnitId.Text),txtUnit.Text))
                {
                    MessageBox.Show("Cập nhật thành công");
                    lbUnit.Text = "Add Unit";
                    btnAddUnit.Text = "Thêm";
                    txtUnit.Text = "";
                    txtUnit.DataBindings.Clear();
                    txtUnitId.DataBindings.Clear();
                    LoadUnit();
                }
                else
                {
                    MessageBox.Show("Đơn vị này đã được tạo");
                }
            }
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            txtSupplierName.IconRight = getValidatorImage(Validator.isValidUnit(txtSupplierName.Text));
        }

        private void txtSupplierAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSupplierPhone_TextChanged(object sender, EventArgs e)
        {
            txtSupplierPhone.IconRight = getValidatorImage(Validator.isValidPhoneNumber(txtSupplierPhone.Text));
        }

        private void txtSupplierEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSupplierInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtSupplierName.Text) && Validator.isValidPhoneNumber(txtSupplierPhone.Text))
            {
                if (SupplierDAO.Ins.CreateSuppler(txtSupplierName.Text,txtSupplierAddress.Text,txtSupplierPhone.Text,txtSupplierEmail.Text,txtSupplierInfo.Text, dtpkSupplierDate.Value.ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("Tạo thành công");
                    LoadSupplier();
                }
                else
                {
                    MessageBox.Show("Chắc có lỗi gì đó :V");
                }
            }

        }

    }
}
