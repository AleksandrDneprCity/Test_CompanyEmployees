namespace Test_CompanyEmployees
{
    partial class DepartmentForm
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
            this.labDepartName = new System.Windows.Forms.Label();
            this.tbDepartName = new System.Windows.Forms.TextBox();
            this.tbParentDepart = new System.Windows.Forms.TextBox();
            this.labParentDepart = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labDepartName
            // 
            this.labDepartName.Location = new System.Drawing.Point(12, 9);
            this.labDepartName.Name = "labDepartName";
            this.labDepartName.Size = new System.Drawing.Size(249, 16);
            this.labDepartName.TabIndex = 3;
            this.labDepartName.Text = "Название подразделения";
            // 
            // tbDepartName
            // 
            this.tbDepartName.Location = new System.Drawing.Point(12, 28);
            this.tbDepartName.MaxLength = 50;
            this.tbDepartName.Name = "tbDepartName";
            this.tbDepartName.Size = new System.Drawing.Size(249, 20);
            this.tbDepartName.TabIndex = 0;
            // 
            // tbParentDepart
            // 
            this.tbParentDepart.Enabled = false;
            this.tbParentDepart.Location = new System.Drawing.Point(12, 84);
            this.tbParentDepart.MaxLength = 50;
            this.tbParentDepart.Name = "tbParentDepart";
            this.tbParentDepart.Size = new System.Drawing.Size(249, 20);
            this.tbParentDepart.TabIndex = 5;
            // 
            // labParentDepart
            // 
            this.labParentDepart.Location = new System.Drawing.Point(12, 65);
            this.labParentDepart.Name = "labParentDepart";
            this.labParentDepart.Size = new System.Drawing.Size(249, 16);
            this.labParentDepart.TabIndex = 4;
            this.labParentDepart.Text = "Дочернее подразделение";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(12, 124);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(106, 24);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(155, 124);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(106, 24);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 160);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tbParentDepart);
            this.Controls.Add(this.labParentDepart);
            this.Controls.Add(this.tbDepartName);
            this.Controls.Add(this.labDepartName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "DepartmentForm";
            this.Text = "Подразделение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labDepartName;
        private System.Windows.Forms.TextBox tbDepartName;
        private System.Windows.Forms.TextBox tbParentDepart;
        private System.Windows.Forms.Label labParentDepart;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butCancel;
    }
}