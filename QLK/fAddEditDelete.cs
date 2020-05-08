using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms.BunifuTextbox;
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
            tabLoad1.BringToFront();
            addControlDock();
            LoadUnit();
            LoadColor();
            LoadGeneration();
            LoadSupplier();
            HideAllID();
            timerLoadPage.Start();
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
                pnTop,SeparatorTop,
                tabUnit,tabColor,tabGeneration,tabSupplier,tabCustomer,tabUser,
                pnUnit,pnColorLeft,pnGenerationLeft,
                pcUnit,pcColor,pcGeneration,
                lbUnit,lbColor,lbGeneration,
                dtgvUnit,dtgvColor,dtgvGeneration,dtgvSupplier,dtgvCustomer,
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

        private void HideAllID()
        {
            txtUnitId.Enabled = false;
            txtColorId.Enabled = false;
            txtGenerationId.Enabled = false;
        }
        //Load data
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

        private void LoadColor()
        {
            dtgvColor.Columns.Clear();
            dtgvColor.DataSource = ColorALDAO.Ins.LoadColor();
            dtgvColor.Columns[0].HeaderText = "Id";
            dtgvColor.Columns[0].Width = 50;
            dtgvColor.Columns[1].HeaderText = "Tên màu";
            dtgvColor.Columns.Add(addButtonDataGrid("Edit"));
            dtgvColor.Columns.Add(addButtonDataGrid("Delete"));
            dtgvColor.Columns[2].Width = 40;
            dtgvColor.Columns[3].Width = 60;
        }

        private void LoadGeneration()
        {
            dtgvGeneration.Columns.Clear();
            dtgvGeneration.DataSource = GenerationDAO.Ins.LoadGeneration();
            dtgvGeneration.Columns[0].HeaderText = "Id";
            dtgvGeneration.Columns[0].Width = 50;
            dtgvGeneration.Columns[1].HeaderText = "Tên hệ";
            dtgvGeneration.Columns.Add(addButtonDataGrid("Edit"));
            dtgvGeneration.Columns.Add(addButtonDataGrid("Delete"));
            dtgvGeneration.Columns[2].Width = 40;
            dtgvGeneration.Columns[3].Width = 60;
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

        private void LoadCustomer()
        {
            dtgvCustomer.Columns.Clear();
            dtgvCustomer.DataSource = CustomerDAO.Ins.LoadCustomer();
            dtgvCustomer.Columns[0].HeaderText = "Id";
            dtgvCustomer.Columns[1].HeaderText = "Tên KH";
            dtgvCustomer.Columns[2].HeaderText = "Địa chỉ";
            dtgvCustomer.Columns[3].HeaderText = "SĐT";
            dtgvCustomer.Columns[4].HeaderText = "Email";
            dtgvCustomer.Columns[5].HeaderText = "Thông tin";
            dtgvCustomer.Columns[6].HeaderText = "Ngày hợp tác";

            dtgvCustomer.Columns.Add(addButtonDataGrid("Edit"));
            dtgvCustomer.Columns.Add(addButtonDataGrid("Delete"));
        }

        private void LoadUser()
        {
            //User load datagridview
        }

        //Load TabPage
        private void btnUnit_Click(object sender, EventArgs e)
        {
            tabLoad1.BringToFront();
            tabLoad1.Show();
            PageAddEditDelete.SetPage(0);
            LoadUnit();
            timerLoadPage.Start();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            tabLoad1.BringToFront();
            tabLoad1.Show();
            PageAddEditDelete.SetPage(1);
            LoadColor();
            timerLoadPage.Start();
        }

        private void btnGeneration_Click(object sender, EventArgs e)
        {
            tabLoad1.BringToFront();
            tabLoad1.Show();
            PageAddEditDelete.SetPage(2);
            LoadGeneration();
            timerLoadPage.Start();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            tabLoad1.BringToFront();
            tabLoad1.Show();
            PageAddEditDelete.SetPage(3);
            LoadSupplier();
            timerLoadPage.Start();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            tabLoad1.BringToFront();
            tabLoad1.Show();
            PageAddEditDelete.SetPage(4);
            LoadCustomer();
            timerLoadPage.Start();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            tabLoad1.BringToFront();
            tabLoad1.Show();
            PageAddEditDelete.SetPage(5);
            timerLoadPage.Start();
        }
        //Binding and Delete
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
                string mess = dtgvUnit.Rows[e.RowIndex].Cells["Displayname"].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \""+ mess +"\"", "Delete", MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    int IdUnit = int.Parse(dtgvUnit.Rows[e.RowIndex].Cells["Id"].Value.ToString());
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

        private void dtgvColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                lbColor.Text = "Edit Color";
                btnAddColor.Text = "Sửa";
                txtColor.DataBindings.Clear();
                txtColorId.DataBindings.Clear();
                txtColor.DataBindings.Add(new Binding("Text", dtgvColor.DataSource, "Displayname", true, DataSourceUpdateMode.OnPropertyChanged));
                txtColorId.DataBindings.Add(new Binding("Text", dtgvColor.DataSource, "Id", true, DataSourceUpdateMode.OnPropertyChanged));
            }
            if (e.RowIndex != -1 && e.ColumnIndex == 3)
            {
                string mess = dtgvColor.Rows[e.RowIndex].Cells["Displayname"].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \"" + mess + "\"", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int IdColor = int.Parse(dtgvColor.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    try
                    {
                        if (ColorALDAO.Ins.DeleteColor(IdColor))
                        {
                            LoadColor();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đơn vị này đang được sử dụng không thể xóa");
                    }

                }
            }
        }

        private void dtgvGeneration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                lbGeneration.Text = "Edit Generation";
                btnAddGenneration.Text = "Sửa";
                txtGeneration.DataBindings.Clear();
                txtGenerationId.DataBindings.Clear();
                txtGeneration.DataBindings.Add(new Binding("Text", dtgvGeneration.DataSource, "Displayname", true, DataSourceUpdateMode.OnPropertyChanged));
                txtGenerationId.DataBindings.Add(new Binding("Text", dtgvGeneration.DataSource, "Id", true, DataSourceUpdateMode.OnPropertyChanged));
            }
            if (e.RowIndex != -1 && e.ColumnIndex == 3)
            {
                string mess = dtgvGeneration.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \"" + mess + "\"", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int IdGeneration = int.Parse(dtgvGeneration.Rows[e.RowIndex].Cells[0].Value.ToString());
                    try
                    {
                        if (GenerationDAO.Ins.DeleteGeneration(IdGeneration))
                        {
                            LoadGeneration();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Đơn vị này đang được sử dụng không thể xóa");
                    }

                }
            }
        }
        //Validator
        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            txtUnit.IconRight = getValidatorImage(Validator.isValidUnit(txtUnit.Text));
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
        //Add and Edit
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

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtColor.Text) && btnAddColor.Text == "Thêm")
            {
                if (ColorALDAO.Ins.CreateColor(txtColor.Text))
                {
                    MessageBox.Show("Tạo thành công");
                    LoadColor();
                }
                else
                {
                    MessageBox.Show("Màu này đã được tạo");
                }
            }
            if (Validator.isValidUnit(txtColor.Text) && btnAddColor.Text == "Sửa")
            {
                if (ColorALDAO.Ins.UpdateColor(int.Parse(txtColorId.Text), txtColor.Text))
                {
                    MessageBox.Show("Cập nhật thành công");
                    lbColor.Text = "Add Color";
                    btnAddColor.Text = "Thêm";
                    txtColor.Text = "";
                    txtColor.DataBindings.Clear();
                    txtColorId.DataBindings.Clear();
                    LoadColor();
                }
                else
                {
                    MessageBox.Show("Màu này đã được tạo");
                }
            }
        }

        private void btnAddGenneration_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtGeneration.Text) && btnAddGenneration.Text == "Thêm")
            {
                if (GenerationDAO.Ins.CreateGeneration(txtGeneration.Text))
                {
                    MessageBox.Show("Tạo thành công");
                    LoadGeneration();
                }
                else
                {
                    MessageBox.Show("Hệ này đã được tạo");
                }
            }
            if (Validator.isValidUnit(txtGeneration.Text) && btnAddGenneration.Text == "Sửa")
            {
                if (GenerationDAO.Ins.UpdateGeneration(int.Parse(txtGenerationId.Text), txtGeneration.Text))
                {
                    MessageBox.Show("Cập nhật thành công");
                    lbGeneration.Text = "Add Generation";
                    btnAddGenneration.Text = "Thêm";
                    txtGeneration.Text = "";
                    txtGeneration.DataBindings.Clear();
                    txtGenerationId.DataBindings.Clear();
                    LoadGeneration();
                }
                else
                {
                    MessageBox.Show("Hệ này đã được tạo");
                }
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtSupplierName.Text) && Validator.isValidPhoneNumber(txtSupplierPhone.Text))
            {
                if (SupplierDAO.Ins.CreateSuppler(txtSupplierName.Text, txtSupplierAddress.Text, txtSupplierPhone.Text, txtSupplierEmail.Text, txtSupplierInfo.Text, dtpkSupplierDate.Value.ToString("yyyy/MM/dd")))
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

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtCustomerName.Text) && Validator.isValidPhoneNumber(txtCustomerPhone.Text))
            {
                if (CustomerDAO.Ins.CreateCustomer(txtCustomerName.Text, txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerEmail.Text, txtCustomerInfo.Text, dtpkCustomerDate.Value.ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("Tạo thành công");
                    LoadCustomer();
                }
                else
                {
                    MessageBox.Show("Chắc có lỗi gì đó :V");
                }
            }
        }

        private void timerLoadPage_Tick(object sender, EventArgs e)
        {
            TransitionPage.Hide(tabLoad1);
            timerLoadPage.Stop();
        }
    }
}
