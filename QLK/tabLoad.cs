using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLK
{
    public partial class tabLoad : UserControl
    {
        public tabLoad()
        {
            InitializeComponent();
        }
        int dir = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CircleProgressLoad.Value == 90  || CircleProgressLoadcon.Value == 10)
            {
                dir = -1;
                CircleProgressLoad.AnimationSpeed = 4;
                CircleProgressLoadcon.AnimationSpeed = 2;
            }
            else if (CircleProgressLoad.Value == 10 || CircleProgressLoadcon.Value == 90)
            {
                dir = 1;
                CircleProgressLoad.AnimationSpeed = 2;
                CircleProgressLoadcon.AnimationSpeed = 4;
            }
            CircleProgressLoad.Value += dir;
            CircleProgressLoadcon.Value = 90 - CircleProgressLoad.Value;

        }
    }
}
