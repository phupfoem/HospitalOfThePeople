
namespace HospitalOfThePeople
{
    partial class FmPatient
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtBDate = new System.Windows.Forms.TextBox();
            this.txtIcn = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblBDate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIcn = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(75, 90);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(484, 22);
            this.txtAddress.TabIndex = 29;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(118, 64);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(441, 22);
            this.txtPhoneNo.TabIndex = 28;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(320, 38);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(239, 22);
            this.txtLName.TabIndex = 27;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(60, 38);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(241, 22);
            this.txtFName.TabIndex = 26;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(505, 10);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(54, 22);
            this.txtGender.TabIndex = 25;
            // 
            // txtBDate
            // 
            this.txtBDate.Location = new System.Drawing.Point(298, 12);
            this.txtBDate.Name = "txtBDate";
            this.txtBDate.Size = new System.Drawing.Size(136, 22);
            this.txtBDate.TabIndex = 24;
            // 
            // txtIcn
            // 
            this.txtIcn.Location = new System.Drawing.Point(45, 12);
            this.txtIcn.Name = "txtIcn";
            this.txtIcn.Size = new System.Drawing.Size(180, 22);
            this.txtIcn.TabIndex = 23;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(440, 15);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(60, 17);
            this.lblGender.TabIndex = 22;
            this.lblGender.Text = "Gender:";
            // 
            // lblBDate
            // 
            this.lblBDate.AutoSize = true;
            this.lblBDate.Location = new System.Drawing.Point(232, 15);
            this.lblBDate.Name = "lblBDate";
            this.lblBDate.Size = new System.Drawing.Size(69, 17);
            this.lblBDate.TabIndex = 21;
            this.lblBDate.Text = "Birthdate:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(5, 93);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 17);
            this.lblAddress.TabIndex = 20;
            this.lblAddress.Text = "Address:";
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(5, 67);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(107, 17);
            this.lblPhoneNo.TabIndex = 19;
            this.lblPhoneNo.Text = "Phone Number:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(5, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Name:";
            // 
            // lblIcn
            // 
            this.lblIcn.AutoSize = true;
            this.lblIcn.Location = new System.Drawing.Point(5, 15);
            this.lblIcn.Name = "lblIcn";
            this.lblIcn.Size = new System.Drawing.Size(34, 17);
            this.lblIcn.TabIndex = 17;
            this.lblIcn.Text = "ICN:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(428, 134);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 46);
            this.btnDelete.TabIndex = 49;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(305, 134);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 46);
            this.btnUpdate.TabIndex = 48;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(186, 134);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 46);
            this.btnFind.TabIndex = 47;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(60, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 46);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // FmPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 193);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtBDate);
            this.Controls.Add(this.txtIcn);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblBDate);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhoneNo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblIcn);
            this.Name = "FmPatient";
            this.Text = "Patient Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtBDate;
        private System.Windows.Forms.TextBox txtIcn;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblBDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIcn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAdd;
    }
}