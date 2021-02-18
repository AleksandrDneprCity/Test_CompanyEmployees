namespace Test_CompanyEmployees
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Кампания");
            this.treeDepartments = new System.Windows.Forms.TreeView();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.butAddEmp = new System.Windows.Forms.Button();
            this.butEditEmp = new System.Windows.Forms.Button();
            this.butDeleteEmp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // treeDepartments
            // 
            this.treeDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeDepartments.HideSelection = false;
            this.treeDepartments.Location = new System.Drawing.Point(12, 10);
            this.treeDepartments.Name = "treeDepartments";
            treeNode3.Name = "root";
            treeNode3.Text = "Кампания";
            this.treeDepartments.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeDepartments.Size = new System.Drawing.Size(350, 429);
            this.treeDepartments.TabIndex = 0;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(368, 10);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(420, 399);
            this.dgvEmployees.TabIndex = 1;
            // 
            // butAddEmp
            // 
            this.butAddEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAddEmp.Location = new System.Drawing.Point(368, 415);
            this.butAddEmp.Name = "butAddEmp";
            this.butAddEmp.Size = new System.Drawing.Size(99, 23);
            this.butAddEmp.TabIndex = 2;
            this.butAddEmp.Text = "Добавить";
            this.butAddEmp.UseVisualStyleBackColor = true;
            this.butAddEmp.Click += new System.EventHandler(this.butAddEmp_Click);
            // 
            // butEditEmp
            // 
            this.butEditEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butEditEmp.Location = new System.Drawing.Point(473, 415);
            this.butEditEmp.Name = "butEditEmp";
            this.butEditEmp.Size = new System.Drawing.Size(99, 23);
            this.butEditEmp.TabIndex = 3;
            this.butEditEmp.Text = "Изменить";
            this.butEditEmp.UseVisualStyleBackColor = true;
            this.butEditEmp.Click += new System.EventHandler(this.butEditEmp_Click);
            // 
            // butDeleteEmp
            // 
            this.butDeleteEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDeleteEmp.Location = new System.Drawing.Point(578, 415);
            this.butDeleteEmp.Name = "butDeleteEmp";
            this.butDeleteEmp.Size = new System.Drawing.Size(99, 23);
            this.butDeleteEmp.TabIndex = 4;
            this.butDeleteEmp.Text = "Удалить";
            this.butDeleteEmp.UseVisualStyleBackColor = true;
            this.butDeleteEmp.Click += new System.EventHandler(this.butDeleteEmp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butDeleteEmp);
            this.Controls.Add(this.butEditEmp);
            this.Controls.Add(this.butAddEmp);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.treeDepartments);
            this.Name = "MainForm";
            this.Text = "Company Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeDepartments;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button butAddEmp;
        private System.Windows.Forms.Button butEditEmp;
        private System.Windows.Forms.Button butDeleteEmp;
    }
}

