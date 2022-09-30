namespace RS2_Vjezba.WinUI
{
    partial class mdiMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.KorisnicitoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PretragatoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKorisnikatoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 671);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KorisnicitoolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(843, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // KorisnicitoolStripMenuItem1
            // 
            this.KorisnicitoolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PretragatoolStripMenuItem1,
            this.dodajKorisnikatoolStripMenuItem1});
            this.KorisnicitoolStripMenuItem1.Name = "KorisnicitoolStripMenuItem1";
            this.KorisnicitoolStripMenuItem1.Size = new System.Drawing.Size(79, 24);
            this.KorisnicitoolStripMenuItem1.Text = "Korisnici";
            // 
            // PretragatoolStripMenuItem1
            // 
            this.PretragatoolStripMenuItem1.Name = "PretragatoolStripMenuItem1";
            this.PretragatoolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.PretragatoolStripMenuItem1.Text = "Pretraga";
            this.PretragatoolStripMenuItem1.Click += new System.EventHandler(this.PretragatoolStripMenuItem1_Click);
            // 
            // dodajKorisnikatoolStripMenuItem1
            // 
            this.dodajKorisnikatoolStripMenuItem1.Name = "dodajKorisnikatoolStripMenuItem1";
            this.dodajKorisnikatoolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.dodajKorisnikatoolStripMenuItem1.Text = "Dodaj korisnika";
            this.dodajKorisnikatoolStripMenuItem1.Click += new System.EventHandler(this.dodajKorisnikatoolStripMenuItem1_Click);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "mdiMain";
            this.Text = "MDIParent1";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem KorisnicitoolStripMenuItem1;
        private ToolStripMenuItem PretragatoolStripMenuItem1;
        private ToolStripMenuItem dodajKorisnikatoolStripMenuItem1;
    }
}



