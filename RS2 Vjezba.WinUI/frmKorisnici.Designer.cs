﻿namespace RS2_Vjezba.WinUI
{
    partial class frmKorisnici
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
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToOrderColumns = true;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime,
            this.Prezime,
            this.RoleNames,
            this.Status});
            this.dgvKorisnici.Location = new System.Drawing.Point(12, 111);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.RowHeadersWidth = 51;
            this.dgvKorisnici.RowTemplate.Height = 29;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(776, 327);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellContentClick);
            // 
            // Ime
            // 
            this.Ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.MinimumWidth = 6;
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.MinimumWidth = 6;
            this.Prezime.Name = "Prezime";
            // 
            // RoleNames
            // 
            this.RoleNames.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoleNames.DataPropertyName = "RoleNames";
            this.RoleNames.HeaderText = "RoleNames";
            this.RoleNames.MinimumWidth = 6;
            this.RoleNames.Name = "RoleNames";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(694, 51);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 29);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(334, 51);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(295, 27);
            this.txtIme.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 51);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(295, 27);
            this.txtUsername.TabIndex = 3;
            // 
            // frmKorisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvKorisnici);
            this.Name = "frmKorisnici";
            this.Text = "frmKorisnici";
            this.Load += new System.EventHandler(this.frmKorisnici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvKorisnici;
        private Button btnShow;
        private TextBox txtIme;
        private TextBox txtUsername;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn RoleNames;
        private DataGridViewCheckBoxColumn Status;
    }
}