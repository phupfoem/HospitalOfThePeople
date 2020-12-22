
namespace HospitalOfThePeople
{
    partial class FmGuardian
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRelationship = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtPIcn = new System.Windows.Forms.TextBox();
            this.lblRelationship = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPIcn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(399, 117);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 46);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(276, 117);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 46);
            this.btnUpdate.TabIndex = 65;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(157, 117);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 46);
            this.btnFind.TabIndex = 64;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(31, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 46);
            this.btnAdd.TabIndex = 63;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtRelationship
            // 
            this.txtRelationship.Location = new System.Drawing.Point(370, 10);
            this.txtRelationship.Name = "txtRelationship";
            this.txtRelationship.Size = new System.Drawing.Size(133, 22);
            this.txtRelationship.TabIndex = 62;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(122, 70);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(381, 22);
            this.txtPhoneNo.TabIndex = 61;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(277, 38);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(226, 22);
            this.txtLName.TabIndex = 60;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(64, 38);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(204, 22);
            this.txtFName.TabIndex = 59;
            // 
            // txtPIcn
            // 
            this.txtPIcn.Location = new System.Drawing.Point(88, 10);
            this.txtPIcn.Name = "txtPIcn";
            this.txtPIcn.Size = new System.Drawing.Size(180, 22);
            this.txtPIcn.TabIndex = 56;
            // 
            // lblRelationship
            // 
            this.lblRelationship.AutoSize = true;
            this.lblRelationship.Location = new System.Drawing.Point(274, 13);
            this.lblRelationship.Name = "lblRelationship";
            this.lblRelationship.Size = new System.Drawing.Size(90, 17);
            this.lblRelationship.TabIndex = 53;
            this.lblRelationship.Text = "Relationship:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(9, 73);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 17);
            this.lblPhone.TabIndex = 52;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 51;
            this.lblName.Text = "Name:";
            // 
            // lblPIcn
            // 
            this.lblPIcn.AutoSize = true;
            this.lblPIcn.Location = new System.Drawing.Point(9, 15);
            this.lblPIcn.Name = "lblPIcn";
            this.lblPIcn.Size = new System.Drawing.Size(82, 17);
            this.lblPIcn.TabIndex = 50;
            this.lblPIcn.Text = "Patient ICN:";
            // 
            // FmGuardian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 182);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtRelationship);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtPIcn);
            this.Controls.Add(this.lblRelationship);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPIcn);
            this.Name = "FmGuardian";
            this.Text = "Guardian Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRelationship;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtPIcn;
        private System.Windows.Forms.Label lblRelationship;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPIcn;
    }
}