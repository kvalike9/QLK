namespace QLK
{
    partial class tabLoad
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bunifuHTTP_Utils1 = new Bunifu.Framework.UI.BunifuHTTP_Utils(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.CircleProgressLoad = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CircleProgressLoadcon = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.SuspendLayout();
            // 
            // bunifuHTTP_Utils1
            // 
            this.bunifuHTTP_Utils1.JobName = "";
            this.bunifuHTTP_Utils1.Url = "";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // CircleProgressLoad
            // 
            this.CircleProgressLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CircleProgressLoad.Animated = true;
            this.CircleProgressLoad.AnimationInterval = 6;
            this.CircleProgressLoad.AnimationSpeed = 1;
            this.CircleProgressLoad.BackColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoad.CircleMargin = 10;
            this.CircleProgressLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold);
            this.CircleProgressLoad.ForeColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoad.IsPercentage = true;
            this.CircleProgressLoad.LineProgressThickness = 8;
            this.CircleProgressLoad.LineThickness = 5;
            this.CircleProgressLoad.Location = new System.Drawing.Point(500, 185);
            this.CircleProgressLoad.Name = "CircleProgressLoad";
            this.CircleProgressLoad.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.CircleProgressLoad.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.CircleProgressLoad.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.CircleProgressLoad.Size = new System.Drawing.Size(200, 200);
            this.CircleProgressLoad.SubScriptColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoad.SubScriptMargin = new System.Windows.Forms.Padding(5, -35, 0, 0);
            this.CircleProgressLoad.SubScriptText = "";
            this.CircleProgressLoad.SuperScriptColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoad.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.CircleProgressLoad.SuperScriptText = "%";
            this.CircleProgressLoad.TabIndex = 16;
            this.CircleProgressLoad.Text = "30";
            this.CircleProgressLoad.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.CircleProgressLoad.Value = 30;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CircleProgressLoadcon
            // 
            this.CircleProgressLoadcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CircleProgressLoadcon.Animated = true;
            this.CircleProgressLoadcon.AnimationInterval = 6;
            this.CircleProgressLoadcon.AnimationSpeed = 1;
            this.CircleProgressLoadcon.BackColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoadcon.CircleMargin = 10;
            this.CircleProgressLoadcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold);
            this.CircleProgressLoadcon.ForeColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoadcon.IsPercentage = true;
            this.CircleProgressLoadcon.LineProgressThickness = 8;
            this.CircleProgressLoadcon.LineThickness = 5;
            this.CircleProgressLoadcon.Location = new System.Drawing.Point(550, 235);
            this.CircleProgressLoadcon.Name = "CircleProgressLoadcon";
            this.CircleProgressLoadcon.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.CircleProgressLoadcon.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.CircleProgressLoadcon.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.CircleProgressLoadcon.Size = new System.Drawing.Size(100, 100);
            this.CircleProgressLoadcon.SubScriptColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoadcon.SubScriptMargin = new System.Windows.Forms.Padding(5, -35, 0, 0);
            this.CircleProgressLoadcon.SubScriptText = "";
            this.CircleProgressLoadcon.SuperScriptColor = System.Drawing.Color.Transparent;
            this.CircleProgressLoadcon.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.CircleProgressLoadcon.SuperScriptText = "%";
            this.CircleProgressLoadcon.TabIndex = 17;
            this.CircleProgressLoadcon.Text = "70";
            this.CircleProgressLoadcon.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.CircleProgressLoadcon.Value = 70;
            // 
            // tabLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.CircleProgressLoadcon);
            this.Controls.Add(this.CircleProgressLoad);
            this.Name = "tabLoad";
            this.Size = new System.Drawing.Size(1200, 570);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuHTTP_Utils bunifuHTTP_Utils1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuCircleProgress CircleProgressLoad;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.WinForms.BunifuCircleProgress CircleProgressLoadcon;
    }
}
