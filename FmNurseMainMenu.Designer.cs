
namespace HospitalOfThePeople
{
    partial class FmNurseMainMenu
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
            this.btnGuardian = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnAdmission = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGuardian
            // 
            this.btnGuardian.Location = new System.Drawing.Point(12, 102);
            this.btnGuardian.Name = "btnGuardian";
            this.btnGuardian.Size = new System.Drawing.Size(134, 39);
            this.btnGuardian.TabIndex = 20;
            this.btnGuardian.Text = "Guardian";
            this.btnGuardian.UseVisualStyleBackColor = true;
            // 
            // btnPatient
            // 
            this.btnPatient.Location = new System.Drawing.Point(12, 57);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(134, 39);
            this.btnPatient.TabIndex = 19;
            this.btnPatient.Text = "Patient";
            this.btnPatient.UseVisualStyleBackColor = true;
            // 
            // btnAdmission
            // 
            this.btnAdmission.Location = new System.Drawing.Point(12, 12);
            this.btnAdmission.Name = "btnAdmission";
            this.btnAdmission.Size = new System.Drawing.Size(134, 39);
            this.btnAdmission.TabIndex = 18;
            this.btnAdmission.Text = "Admission";
            this.btnAdmission.UseVisualStyleBackColor = true;
            // 
            // FmNurseMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(158, 157);
            this.Controls.Add(this.btnGuardian);
            this.Controls.Add(this.btnPatient);
            this.Controls.Add(this.btnAdmission);
            this.Name = "FmNurseMainMenu";
            this.Text = "Nurse Main Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGuardian;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnAdmission;
    }
}