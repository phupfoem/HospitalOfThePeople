
namespace HospitalOfThePeople
{
    partial class FmMainMenu
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
            this.lblIcn = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdmit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddr = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblGen = new System.Windows.Forms.Label();
            this.lblBdate = new System.Windows.Forms.Label();
            this.txtIcn = new System.Windows.Forms.TextBox();
            this.txtBdate = new System.Windows.Forms.TextBox();
            this.txtGen = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIcn
            // 
            this.lblIcn.AutoSize = true;
            this.lblIcn.Location = new System.Drawing.Point(12, 18);
            this.lblIcn.Name = "lblIcn";
            this.lblIcn.Size = new System.Drawing.Size(34, 17);
            this.lblIcn.TabIndex = 0;
            this.lblIcn.Text = "ICN:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(106, 141);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 39);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += this.BtnAdd_Click;
            // 
            // btnAdmit
            // 
            this.btnAdmit.Location = new System.Drawing.Point(272, 141);
            this.btnAdmit.Name = "btnAdmit";
            this.btnAdmit.Size = new System.Drawing.Size(85, 39);
            this.btnAdmit.TabIndex = 3;
            this.btnAdmit.Text = "Admit";
            this.btnAdmit.UseVisualStyleBackColor = true;
            this.btnAdmit.Click += this.BtnAdmit_Click;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(440, 141);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 39);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // lblAddr
            // 
            this.lblAddr.AutoSize = true;
            this.lblAddr.Location = new System.Drawing.Point(12, 96);
            this.lblAddr.Name = "lblAddr";
            this.lblAddr.Size = new System.Drawing.Size(64, 17);
            this.lblAddr.TabIndex = 7;
            this.lblAddr.Text = "Address:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 70);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 17);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblGen
            // 
            this.lblGen.AutoSize = true;
            this.lblGen.Location = new System.Drawing.Point(447, 18);
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(60, 17);
            this.lblGen.TabIndex = 9;
            this.lblGen.Text = "Gender:";
            // 
            // lblBdate
            // 
            this.lblBdate.AutoSize = true;
            this.lblBdate.Location = new System.Drawing.Point(239, 18);
            this.lblBdate.Name = "lblBdate";
            this.lblBdate.Size = new System.Drawing.Size(69, 17);
            this.lblBdate.TabIndex = 8;
            this.lblBdate.Text = "Birthdate:";
            // 
            // txtIcn
            // 
            this.txtIcn.Location = new System.Drawing.Point(52, 15);
            this.txtIcn.Name = "txtIcn";
            this.txtIcn.Size = new System.Drawing.Size(180, 22);
            this.txtIcn.TabIndex = 10;
            // 
            // txtBdate
            // 
            this.txtBdate.Location = new System.Drawing.Point(305, 15);
            this.txtBdate.Name = "txtBdate";
            this.txtBdate.Size = new System.Drawing.Size(136, 22);
            this.txtBdate.TabIndex = 11;
            // 
            // txtGen
            // 
            this.txtGen.Location = new System.Drawing.Point(512, 13);
            this.txtGen.Name = "txtGen";
            this.txtGen.Size = new System.Drawing.Size(85, 22);
            this.txtGen.TabIndex = 12;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(67, 41);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(241, 22);
            this.txtFname.TabIndex = 13;
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(327, 41);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(270, 22);
            this.txtLname.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(125, 67);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(472, 22);
            this.txtPhone.TabIndex = 15;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(82, 93);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(515, 22);
            this.txtAddr.TabIndex = 16;
            // 
            // FmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 196);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtGen);
            this.Controls.Add(this.txtBdate);
            this.Controls.Add(this.txtIcn);
            this.Controls.Add(this.lblGen);
            this.Controls.Add(this.lblBdate);
            this.Controls.Add(this.lblAddr);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAdmit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblIcn);
            this.Name = "FmMainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += this.FmMainMenu_Load;
            this.FormClosing += this.FmMainMenu_FormClosing;

        }
        #endregion

        private System.Windows.Forms.Label lblIcn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAdmit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddr;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblGen;
        private System.Windows.Forms.Label lblBdate;
        private System.Windows.Forms.TextBox txtIcn;
        private System.Windows.Forms.TextBox txtBdate;
        private System.Windows.Forms.TextBox txtGen;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddr;
    }
}