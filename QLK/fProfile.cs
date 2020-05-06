using Bunifu.UI.WinForms.BunifuButton;
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
        private User loginUser;

        public User LoginUser {
            get  { return loginUser; }
            set { loginUser = value; }
        }

        public fProfile(User user)
        {
            InitializeComponent();
            lbDisplayName.Text = "Hello "+user.DisplayName;
        }

        private void fProfile_Load(object sender, EventArgs e)
        {
            addControlDock();
            ChartRender();
        }

        private void ChartRender()
        {
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint dataPoint = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_column);
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                //dataPoint.addxy("new Date (2020, 4, "+i+")", random.Next(1, 100));
                dataPoint.addxy("new Date (2020, 10, " + i + ")", random.Next(1, 100));
            }
            canvas.addData(dataPoint);
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangeSprtr(sender, e);
            //MessageBox.Show("CLick me!");
            bunifuPages1.SetPage(0);
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
        }

        private void ChangeSprtr(object sender, EventArgs e)
        {
            Sprtr.Height = ((BunifuButton)sender).Height - 4;
            Sprtr.Top = ((BunifuButton)sender).Top + 2;
        }

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

        
    }
}
