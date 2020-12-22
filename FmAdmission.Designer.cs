
namespace HospitalOfThePeople
{
    partial class FmAdmission
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
            this.txtPIcn = new System.Windows.Forms.TextBox();
            this.lblPIcn = new System.Windows.Forms.Label();
            this.lblNIcn = new System.Windows.Forms.Label();
            this.txtNIcn = new System.Windows.Forms.TextBox();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.btnAdmit = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPIcn
            // 
            this.txtPIcn.Location = new System.Drawing.Point(143, 17);
            this.txtPIcn.Name = "txtPIcn";
            this.txtPIcn.Size = new System.Drawing.Size(192, 22);
            this.txtPIcn.TabIndex = 0;
            // 
            // lblPIcn
            // 
            this.lblPIcn.AutoSize = true;
            this.lblPIcn.Location = new System.Drawing.Point(30, 20);
            this.lblPIcn.Name = "lblPIcn";
            this.lblPIcn.Size = new System.Drawing.Size(78, 17);
            this.lblPIcn.TabIndex = 1;
            this.lblPIcn.Text = "Patient ICN";
            // 
            // lblNIcn
            // 
            this.lblNIcn.AutoSize = true;
            this.lblNIcn.Location = new System.Drawing.Point(30, 62);
            this.lblNIcn.Name = "lblNIcn";
            this.lblNIcn.Size = new System.Drawing.Size(72, 17);
            this.lblNIcn.TabIndex = 3;
            this.lblNIcn.Text = "Nurse ICN";
            // 
            // txtNIcn
            // 
            this.txtNIcn.Location = new System.Drawing.Point(143, 59);
            this.txtNIcn.Name = "txtNIcn";
            this.txtNIcn.Size = new System.Drawing.Size(192, 22);
            this.txtNIcn.TabIndex = 2;
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Location = new System.Drawing.Point(30, 103);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(98, 17);
            this.lblTimeIn.TabIndex = 5;
            this.lblTimeIn.Text = "Check-in Time";
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Location = new System.Drawing.Point(143, 100);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(192, 22);
            this.txtTimeIn.TabIndex = 4;
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(30, 144);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(107, 17);
            this.lblTimeOut.TabIndex = 7;
            this.lblTimeOut.Text = "Check-out Time";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(143, 141);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(192, 22);
            this.txtTimeOut.TabIndex = 6;
            // 
            // btnAdmit
            // 
            this.btnAdmit.Location = new System.Drawing.Point(33, 192);
            this.btnAdmit.Name = "btnAdmit";
            this.btnAdmit.Size = new System.Drawing.Size(148, 46);
            this.btnAdmit.TabIndex = 8;
            this.btnAdmit.Text = "Admit";
            this.btnAdmit.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(187, 192);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(148, 46);
            this.btnCheck.TabIndex = 9;
            this.btnCheck.Text = "Find";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(33, 260);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(148, 46);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(187, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 46);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // FmAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 340);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAdmit);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.lblNIcn);
            this.Controls.Add(this.txtNIcn);
            this.Controls.Add(this.lblPIcn);
            this.Controls.Add(this.txtPIcn);
            this.Name = "FmAdm";
            this.Text = "Admission Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPIcn;
        private System.Windows.Forms.Label lblPIcn;
        private System.Windows.Forms.Label lblNIcn;
        private System.Windows.Forms.TextBox txtNIcn;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.Button btnAdmit;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}