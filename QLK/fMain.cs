using QLK.DAO;
using QLK.DTO;
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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            addControlDock();
            //MessageBox.Show("Load");
            ClickShowSignInOrSignUp();
        }

        private void addCheckRememberMe()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                if (Properties.Settings.Default.RememberMe == "yes")
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                    txtPassword.Text = Properties.Settings.Default.Password;
                    chkRememberme.Checked = true;
                }
                else
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                }
                
            }
        }

        private void ClickShowSignInOrSignUp()
        {
            if (Properties.Settings.Default.CheckSignUp == "yes")
            {
                //MessageBox.Show("yes");
                tabALL.SetPage(1);
                addCheckRememberMe();
            }
            else
            {
                //MessageBox.Show("no");
                tabALL.SetPage(0);
            }
        }


        private void addControlDock()
        {
            ControlDock.SubscribeControlsToDragEvents(new Control[] {
                bunifuGradientPanel1,
                tabSignUp,
                tabSignIn,
                tabALL,
                pictureBox1,
                pictureBox2,
                bunifuLabel1,
                bunifuLabel2,
                bunifuLabel3
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

        private void btnShowSignIn_Click(object sender, EventArgs e)
        {
            tabALL.SetPage(1);
            Properties.Settings.Default.CheckSignUp = "yes";
            Properties.Settings.Default.Save();
            addCheckRememberMe();
        }

        private void btnShowSignUp_Click(object sender, EventArgs e)
        {
            tabALL.SetPage(0);
            Properties.Settings.Default.CheckSignUp = "no";
            Properties.Settings.Default.Save();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            txtFullName.IconRight = getValidatorImage(Validator.isValidName(txtFullName.Text));
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (UserDAO.Ins.CheckUsername(txtUser.Text))
            {
                txtUser.IconRight = getValidatorImage(false);
                lbError.Text = "Tên người dùng đã được sử dụng. Hãy thử tên khác";
                lbError.Visible = true;
                btnSignUp.Enabled = false;
            }
            else
            {
                txtUser.IconRight = getValidatorImage(Validator.isValidUsernameName(txtUser.Text));
                lbError.Visible = false;
                btnSignUp.Enabled = true;

            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.IconRight = getValidatorImage(Validator.isValidPassword(txtPass.Text));
            if (txtPass.Text != "")
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.PlaceholderText = "Enter Password";
            }
        }

        private void txtConPass_TextChanged(object sender, EventArgs e)
        {
            txtConPass.IconRight = getValidatorImage(txtPass.Text == txtConPass.Text);
            if (txtConPass.Text != "")
            {
                txtConPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtConPass.UseSystemPasswordChar = false;
                txtConPass.PlaceholderText = "Enter Comfirm Password";
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.IconRight = getValidatorImage(Validator.isValidUsernameName(txtUsername.Text));
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.IconRight = getValidatorImage(Validator.isValidPassword(txtPassword.Text));
            if (txtPassword.Text != "")
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PlaceholderText = "Enter Password";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if(Validator.isValidPassword(txtPass.Text) && txtPass.Text == txtConPass.Text && Validator.isValidName(txtFullName.Text) && Validator.isValidUsernameName(txtUser.Text))
            {
                lbError.Visible = false;
                if (UserDAO.Ins.CreateUser(txtFullName.Text, txtUser.Text, txtPass.Text))
                {
                    MessageBox.Show("Tạo tài khoản thành công");
                    tabALL.SetPage(1);
                }
                else
                {
                    txtUser.IconRight = getValidatorImage(false);
                    MessageBox.Show("Tài khoản đã bị trùng");
                }
            }
            else
            {
                txtFullName.IconRight = getValidatorImage(Validator.isValidName(txtFullName.Text));
                if (UserDAO.Ins.CheckUsername(txtUser.Text))
                {
                    txtUser.IconRight = getValidatorImage(false);
                }
                else
                {
                    txtUser.IconRight = getValidatorImage(Validator.isValidUsernameName(txtUser.Text));
                }
                txtPass.IconRight = getValidatorImage(Validator.isValidPassword(txtPass.Text));
                txtConPass.IconRight = getValidatorImage(txtPass.Text == txtConPass.Text && txtConPass.Text != "");
                lbError.Text = "Vui lòng nhập đầy đủ và chính xác";
                lbError.Visible = true;
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Validator.isValidUsernameName(txtUsername.Text) && Validator.isValidPassword(txtPassword.Text))
            {
                lbError2.Visible = false;
                if (chkRememberme.Checked)
                {
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.RememberMe = "yes";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Username = txtUsername.Text;
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.RememberMe = "no";
                    Properties.Settings.Default.Save();
                }
                if (UserDAO.Ins.CheckUsernamePassword(txtUsername.Text, txtPassword.Text))
                {
                    User LoginName = UserDAO.Ins.GetAccountByUserName(txtUsername.Text);
                    this.Visible = false;
                    var home = new fProfile(LoginName);
                    home.ShowDialog();
                    if (home.DialogResult != DialogResult.No) this.Close();
                    this.Visible = true;

                    
                    //MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    lbError2.Text = "Tài khoản hoặc mật khẩu sai. Vui lòng nhập lại";
                    lbError2.Visible = true;
                }
            }
            else
            {
                txtUsername.IconRight = getValidatorImage(Validator.isValidUsernameName(txtUsername.Text));
                txtPassword.IconRight = getValidatorImage(Validator.isValidPassword(txtPassword.Text));
                lbError2.Text = "Vui lòng nhập đầy đủ và chính xác";
                lbError2.Visible = true;
            }
        }
    }
}
