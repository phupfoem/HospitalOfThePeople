
namespace HospitalOfThePeople
{
    partial class FmRoom
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
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblBlock = new System.Windows.Forms.Label();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.lblRNo = new System.Windows.Forms.Label();
            this.txtRNo = new System.Windows.Forms.TextBox();
            this.lblDNo = new System.Windows.Forms.Label();
            this.txtDNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(288, 84);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 46);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(196, 84);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 46);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(108, 84);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 46);
            this.btnFind.TabIndex = 31;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 46);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(14, 37);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 29;
            this.lblType.Text = "Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(56, 37);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(307, 22);
            this.txtType.TabIndex = 28;
            // 
            // lblBlock
            // 
            this.lblBlock.AutoSize = true;
            this.lblBlock.Location = new System.Drawing.Point(120, 12);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(46, 17);
            this.lblBlock.TabIndex = 27;
            this.lblBlock.Text = "Block:";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(171, 9);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(57, 22);
            this.txtBlock.TabIndex = 26;
            // 
            // lblRNo
            // 
            this.lblRNo.AutoSize = true;
            this.lblRNo.Location = new System.Drawing.Point(14, 12);
            this.lblRNo.Name = "lblRNo";
            this.lblRNo.Size = new System.Drawing.Size(40, 17);
            this.lblRNo.TabIndex = 25;
            this.lblRNo.Text = "RNo:";
            // 
            // txtRNo
            // 
            this.txtRNo.Location = new System.Drawing.Point(56, 9);
            this.txtRNo.Name = "txtRNo";
            this.txtRNo.Size = new System.Drawing.Size(56, 22);
            this.txtRNo.TabIndex = 24;
            // 
            // lblDNo
            // 
            this.lblDNo.AutoSize = true;
            this.lblDNo.Location = new System.Drawing.Point(255, 10);
            this.lblDNo.Name = "lblDNo";
            this.lblDNo.Size = new System.Drawing.Size(40, 17);
            this.lblDNo.TabIndex = 35;
            this.lblDNo.Text = "DNo:";
            // 
            // txtDNo
            // 
            this.txtDNo.Location = new System.Drawing.Point(297, 7);
            this.txtDNo.Name = "txtDNo";
            this.txtDNo.Size = new System.Drawing.Size(56, 22);
            this.txtDNo.TabIndex = 34;
            // 
            // FmRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 149);
            this.Controls.Add(this.lblDNo);
            this.Controls.Add(this.txtDNo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblBlock);
            this.Controls.Add(this.txtBlock);
            this.Controls.Add(this.lblRNo);
            this.Controls.Add(this.txtRNo);
            this.Name = "FmRoom";
            this.Text = "Room Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Label lblRNo;
        private System.Windows.Forms.TextBox txtRNo;
        private System.Windows.Forms.Label lblDNo;
        private System.Windows.Forms.TextBox txtDNo;
    }
}