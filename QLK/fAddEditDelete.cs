﻿using Bunifu.Framework.UI;
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
            LoadCustomer();
            LoadUser();
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

        private DataGridViewComboBoxColumn addComboboxDataGrid()
        {
            DataGridViewComboBoxColumn cbx = new DataGridViewComboBoxColumn();
            cbx.DataSource = UserRolesDAO.Ins.LoadUserRoles().ToList();
            cbx.DisplayMember = "DisplayName";
            cbx.ValueMember = "Id";
            return cbx;
        }

        private void addControlDock()
        {
            bunifuFormDock1.SubscribeControlsToDragEvents(new Control[] {
                pnTop,SeparatorTop,tabLoad1,
                tabUnit,tabColor,tabGeneration,tabSupplier,tabCustomer,tabUser,
                pnUnit,pnColorLeft,pnGenerationLeft,pnSupplierLeft,pnCustomerLeft,
                pcUnit,pcColor,pcGeneration,pcSupplier,pcCustomer,pcUser,
                lbUnit,lbColor,lbGeneration,lbSupplier,lbCustomer,lbError,
                dtgvUnit,dtgvColor,dtgvGeneration,dtgvSupplier,dtgvCustomer,dtgvUser,
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

        private void BindingAddText(Control control, string propetyName, DataGridView dataGridView, string dataMember)
        {
            control.DataBindings.Add(new Binding(propetyName, dataGridView.DataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void BindingClearText(Control control)
        {
            control.DataBindings.Clear();
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
            //dtgvUnit.Columns.Add(cbx);
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
            dtgvCustomer.Columns.Add(addComboboxDataGrid());

        }

        private void LoadUser()
        {
            //User load datagridview
            DropDownRoles.DataSource = UserRolesDAO.Ins.LoadUserRoles();
            DropDownRoles.DisplayMember = "DisplayName";
            DropDownRoles.ValueMember = "Id";
            dtgvUser.Columns.Clear();
            dtgvUser.DataSource = UsersDAO.Ins.LoadUsers();
            dtgvUser.Columns[0].HeaderText = "Id";
            dtgvUser.Columns[1].HeaderText = "Họ Tên";
            dtgvUser.Columns[2].HeaderText = "Tên tài khoản";
            dtgvUser.Columns[3].HeaderText = "Quyền";
            dtgvUser.Columns[4].Visible = false;
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
                BindingClearText(txtUnitId);
                BindingClearText(txtUnit);
                BindingAddText(txtUnitId, "Text", dtgvUnit, "Id");
                BindingAddText(txtUnit, "Text", dtgvUnit, "DisplayName");
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
                    catch
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
                BindingClearText(txtColorId);
                BindingClearText(txtColor);
                BindingAddText(txtColorId, "Text", dtgvColor, "Id");
                BindingAddText(txtColor, "Text", dtgvColor, "DisplayName");
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
                    catch
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
                BindingClearText(txtGenerationId);
                BindingClearText(txtGeneration);
                BindingAddText(txtGenerationId, "Text", dtgvGeneration, "Id");
                BindingAddText(txtGeneration, "Text", dtgvGeneration, "DisplayName");
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
                    catch
                    {
                        MessageBox.Show("Đơn vị này đang được sử dụng không thể xóa");
                    }

                }
            }
        }

        private void dtgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 7)
            {
                lbSupplier.Text = "Edit Supplier";
                btnAddSupplier.Text = "Sửa";
                BindingClearText(txtSupplierId);
                BindingClearText(txtSupplierName);
                BindingClearText(txtSupplierAddress);
                BindingClearText(txtSupplierPhone);
                BindingClearText(txtSupplierEmail);
                BindingClearText(txtSupplierInfo);
                BindingClearText(dtpkSupplierDate);
                BindingAddText(txtSupplierId, "Text", dtgvSupplier, "Id");
                BindingAddText(txtSupplierName, "Text", dtgvSupplier, "Displayname");
                BindingAddText(txtSupplierAddress, "Text", dtgvSupplier, "Address");
                BindingAddText(txtSupplierPhone, "Text", dtgvSupplier, "Phone");
                BindingAddText(txtSupplierEmail, "Text", dtgvSupplier, "Email");
                BindingAddText(txtSupplierInfo, "Text", dtgvSupplier, "MoreInfo");
                BindingAddText(dtpkSupplierDate, "Value", dtgvSupplier, "ContractDate");
                //MessageBox.Show(dtpkSupplierDate.Value.ToString("dd/MM/yyyy"));
            }
            if (e.RowIndex != -1 && e.ColumnIndex == 8)
            {
                string mess = dtgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \"" + mess + "\"", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int IdSupplier = int.Parse(dtgvSupplier.Rows[e.RowIndex].Cells[0].Value.ToString());
                    try
                    {
                        if (SupplierDAO.Ins.DeleteSupplier(IdSupplier))
                        {
                            LoadSupplier();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Đơn vị này đang được sử dụng không thể xóa");
                    }

                }
            }
        }

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.ColumnIndex == 7)
            {
                lbCustomer.Text = "Edit Customer";
                btnCustomerAdd.Text = "Sửa";
                BindingClearText(txtCustomerId);
                BindingClearText(txtCustomerName);
                BindingClearText(txtCustomerAddress);
                BindingClearText(txtCustomerPhone);
                BindingClearText(txtCustomerEmail);
                BindingClearText(txtCustomerInfo);
                BindingClearText(dtpkCustomerDate);
                BindingAddText(txtCustomerId, "Text", dtgvCustomer, "Id");
                BindingAddText(txtCustomerName, "Text", dtgvCustomer, "Displayname");
                BindingAddText(txtCustomerAddress, "Text", dtgvCustomer, "Address");
                BindingAddText(txtCustomerPhone, "Text", dtgvCustomer, "Phone");
                BindingAddText(txtCustomerEmail, "Text", dtgvCustomer, "Email");
                BindingAddText(txtCustomerInfo, "Text", dtgvCustomer, "MoreInfo");
                BindingAddText(dtpkCustomerDate, "Value", dtgvCustomer, "ContractDate");
            }
            if (e.RowIndex != -1 && e.ColumnIndex == 8)
            {
                string mess = dtgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa \"" + mess + "\"", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int IdCustomer = int.Parse(dtgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString());
                    try
                    {
                        if (CustomerDAO.Ins.DeleteCustomer(IdCustomer))
                        {
                            LoadCustomer();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Đơn vị này đang được sử dụng không thể xóa");
                    }

                }
            }
        }

        private void dtgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DropDownRoles.SelectedValue = int.Parse(dtgvUser.Rows[e.RowIndex].Cells[4].Value.ToString());
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
                    BindingClearText(txtUnitId);
                    BindingClearText(txtUnit);
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
                    BindingClearText(txtColorId);
                    BindingClearText(txtColor);
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
                    BindingClearText(txtGenerationId);
                    BindingClearText(txtGeneration);
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
            if (Validator.isValidUnit(txtSupplierName.Text) && Validator.isValidPhoneNumber(txtSupplierPhone.Text) && btnAddSupplier.Text == "Thêm")
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
            if (Validator.isValidUnit(txtSupplierName.Text) && btnAddSupplier.Text == "Sửa")
            {
                if (SupplierDAO.Ins.UpdateSuppler(int.Parse(txtSupplierId.Text), txtSupplierName.Text, txtSupplierAddress.Text, txtSupplierPhone.Text, txtSupplierEmail.Text, txtSupplierInfo.Text, dtpkSupplierDate.Value.ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("Cập nhật thành công");
                    lbSupplier.Text = "Add Supplier";
                    btnAddSupplier.Text = "Thêm";

                    txtSupplierId.Clear();
                    txtSupplierName.Clear();
                    txtSupplierAddress.Clear();
                    txtSupplierPhone.Clear();
                    txtSupplierEmail.Clear();
                    txtSupplierInfo.Clear();

                    BindingClearText(txtSupplierId);
                    BindingClearText(txtSupplierName);
                    BindingClearText(txtSupplierAddress);
                    BindingClearText(txtSupplierPhone);
                    BindingClearText(txtSupplierEmail);
                    BindingClearText(txtSupplierInfo);
                    BindingClearText(dtpkSupplierDate);
                    LoadSupplier();
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp này đã được tạo");
                }
            }

        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUnit(txtCustomerName.Text) && Validator.isValidPhoneNumber(txtCustomerPhone.Text) && btnCustomerAdd.Text == "Thêm")
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
            if (Validator.isValidUnit(txtCustomerName.Text) && btnCustomerAdd.Text == "Sửa")
            {
                if (CustomerDAO.Ins.UpdateCustomer(int.Parse(txtCustomerId.Text), txtCustomerName.Text, txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerEmail.Text, txtCustomerInfo.Text, dtpkCustomerDate.Value.ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("Cập nhật thành công");
                    lbCustomer.Text = "Add Customer";
                    btnCustomerAdd.Text = "Thêm";

                    txtCustomerId.Clear();
                    txtCustomerName.Clear();
                    txtCustomerAddress.Clear();
                    txtCustomerPhone.Clear();
                    txtCustomerEmail.Clear();
                    txtCustomerInfo.Clear();

                    BindingClearText(txtCustomerId);
                    BindingClearText(txtCustomerName);
                    BindingClearText(txtCustomerAddress);
                    BindingClearText(txtCustomerPhone);
                    BindingClearText(txtCustomerEmail);
                    BindingClearText(txtCustomerInfo);
                    BindingClearText(dtpkCustomerDate);
                    LoadCustomer();
                }
                else
                {
                    MessageBox.Show("Khách hàng này đã được tạo");
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
