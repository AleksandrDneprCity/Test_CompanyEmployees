namespace Test_CompanyEmployees
{
    partial class EmployeeForm
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
            this.labPersonNumber = new System.Windows.Forms.Label();
            this.tbPersonNumber = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.labLastName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.labFirstName = new System.Windows.Forms.Label();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.labMiddleName = new System.Windows.Forms.Label();
            this.labGender = new System.Windows.Forms.Label();
            this.rbGenderMale = new System.Windows.Forms.RadioButton();
            this.rbGenderFemale = new System.Windows.Forms.RadioButton();
            this.dtBirthDay = new System.Windows.Forms.DateTimePicker();
            this.labBirthDay = new System.Windows.Forms.Label();
            this.tbBirthPlace = new System.Windows.Forms.TextBox();
            this.labBirthPlace = new System.Windows.Forms.Label();
            this.tbTaxNumber = new System.Windows.Forms.TextBox();
            this.labTaxNumber = new System.Windows.Forms.Label();
            this.labEmployDate = new System.Windows.Forms.Label();
            this.dtEmployDate = new System.Windows.Forms.DateTimePicker();
            this.labDismissDate = new System.Windows.Forms.Label();
            this.dtDismissDate = new System.Windows.Forms.DateTimePicker();
            this.labDismissReason = new System.Windows.Forms.Label();
            this.tbDismissReason = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.cbDismiss = new System.Windows.Forms.CheckBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.labDepartment = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.labPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labPersonNumber
            // 
            this.labPersonNumber.Location = new System.Drawing.Point(12, 9);
            this.labPersonNumber.Name = "labPersonNumber";
            this.labPersonNumber.Size = new System.Drawing.Size(199, 15);
            this.labPersonNumber.TabIndex = 17;
            this.labPersonNumber.Text = "Табельный номер";
            // 
            // tbPersonNumber
            // 
            this.tbPersonNumber.Location = new System.Drawing.Point(12, 27);
            this.tbPersonNumber.MaxLength = 10;
            this.tbPersonNumber.Name = "tbPersonNumber";
            this.tbPersonNumber.Size = new System.Drawing.Size(199, 20);
            this.tbPersonNumber.TabIndex = 0;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(293, 16);
            this.tbLastName.MaxLength = 16;
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(178, 20);
            this.tbLastName.TabIndex = 2;
            // 
            // labLastName
            // 
            this.labLastName.Location = new System.Drawing.Point(230, 19);
            this.labLastName.Name = "labLastName";
            this.labLastName.Size = new System.Drawing.Size(57, 15);
            this.labLastName.TabIndex = 19;
            this.labLastName.Text = "Фамилия";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(293, 42);
            this.tbFirstName.MaxLength = 16;
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(178, 20);
            this.tbFirstName.TabIndex = 3;
            // 
            // labFirstName
            // 
            this.labFirstName.Location = new System.Drawing.Point(230, 42);
            this.labFirstName.Name = "labFirstName";
            this.labFirstName.Size = new System.Drawing.Size(57, 15);
            this.labFirstName.TabIndex = 20;
            this.labFirstName.Text = "Имя";
            // 
            // tbMiddleName
            // 
            this.tbMiddleName.Location = new System.Drawing.Point(293, 68);
            this.tbMiddleName.MaxLength = 16;
            this.tbMiddleName.Name = "tbMiddleName";
            this.tbMiddleName.Size = new System.Drawing.Size(178, 20);
            this.tbMiddleName.TabIndex = 4;
            // 
            // labMiddleName
            // 
            this.labMiddleName.Location = new System.Drawing.Point(230, 68);
            this.labMiddleName.Name = "labMiddleName";
            this.labMiddleName.Size = new System.Drawing.Size(57, 15);
            this.labMiddleName.TabIndex = 21;
            this.labMiddleName.Text = "Отчество";
            // 
            // labGender
            // 
            this.labGender.Location = new System.Drawing.Point(259, 109);
            this.labGender.Name = "labGender";
            this.labGender.Size = new System.Drawing.Size(28, 16);
            this.labGender.TabIndex = 22;
            this.labGender.Text = "Пол";
            // 
            // rbGenderMale
            // 
            this.rbGenderMale.Location = new System.Drawing.Point(293, 109);
            this.rbGenderMale.Name = "rbGenderMale";
            this.rbGenderMale.Size = new System.Drawing.Size(72, 16);
            this.rbGenderMale.TabIndex = 5;
            this.rbGenderMale.TabStop = true;
            this.rbGenderMale.Text = "Мужской";
            this.rbGenderMale.UseVisualStyleBackColor = true;
            // 
            // rbGenderFemale
            // 
            this.rbGenderFemale.Location = new System.Drawing.Point(371, 109);
            this.rbGenderFemale.Name = "rbGenderFemale";
            this.rbGenderFemale.Size = new System.Drawing.Size(72, 16);
            this.rbGenderFemale.TabIndex = 6;
            this.rbGenderFemale.TabStop = true;
            this.rbGenderFemale.Text = "Женский";
            this.rbGenderFemale.UseVisualStyleBackColor = true;
            // 
            // dtBirthDay
            // 
            this.dtBirthDay.Location = new System.Drawing.Point(17, 153);
            this.dtBirthDay.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtBirthDay.Name = "dtBirthDay";
            this.dtBirthDay.Size = new System.Drawing.Size(151, 20);
            this.dtBirthDay.TabIndex = 7;
            // 
            // labBirthDay
            // 
            this.labBirthDay.Location = new System.Drawing.Point(17, 134);
            this.labBirthDay.Name = "labBirthDay";
            this.labBirthDay.Size = new System.Drawing.Size(146, 16);
            this.labBirthDay.TabIndex = 23;
            this.labBirthDay.Text = "Дата рождения";
            // 
            // tbBirthPlace
            // 
            this.tbBirthPlace.Location = new System.Drawing.Point(178, 153);
            this.tbBirthPlace.Multiline = true;
            this.tbBirthPlace.Name = "tbBirthPlace";
            this.tbBirthPlace.Size = new System.Drawing.Size(293, 44);
            this.tbBirthPlace.TabIndex = 8;
            // 
            // labBirthPlace
            // 
            this.labBirthPlace.Location = new System.Drawing.Point(175, 134);
            this.labBirthPlace.Name = "labBirthPlace";
            this.labBirthPlace.Size = new System.Drawing.Size(151, 16);
            this.labBirthPlace.TabIndex = 24;
            this.labBirthPlace.Text = "Место рождения";
            // 
            // tbTaxNumber
            // 
            this.tbTaxNumber.Location = new System.Drawing.Point(12, 68);
            this.tbTaxNumber.MaxLength = 10;
            this.tbTaxNumber.Name = "tbTaxNumber";
            this.tbTaxNumber.Size = new System.Drawing.Size(199, 20);
            this.tbTaxNumber.TabIndex = 1;
            // 
            // labTaxNumber
            // 
            this.labTaxNumber.Location = new System.Drawing.Point(12, 50);
            this.labTaxNumber.Name = "labTaxNumber";
            this.labTaxNumber.Size = new System.Drawing.Size(199, 15);
            this.labTaxNumber.TabIndex = 18;
            this.labTaxNumber.Text = "Индивидуальный налоговый номер";
            // 
            // labEmployDate
            // 
            this.labEmployDate.Location = new System.Drawing.Point(15, 209);
            this.labEmployDate.Name = "labEmployDate";
            this.labEmployDate.Size = new System.Drawing.Size(146, 16);
            this.labEmployDate.TabIndex = 25;
            this.labEmployDate.Text = "День приёма на работу";
            // 
            // dtEmployDate
            // 
            this.dtEmployDate.Location = new System.Drawing.Point(15, 228);
            this.dtEmployDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtEmployDate.Name = "dtEmployDate";
            this.dtEmployDate.Size = new System.Drawing.Size(151, 20);
            this.dtEmployDate.TabIndex = 9;
            // 
            // labDismissDate
            // 
            this.labDismissDate.Enabled = false;
            this.labDismissDate.Location = new System.Drawing.Point(17, 354);
            this.labDismissDate.Name = "labDismissDate";
            this.labDismissDate.Size = new System.Drawing.Size(151, 16);
            this.labDismissDate.TabIndex = 28;
            this.labDismissDate.Text = "День увольнения";
            // 
            // dtDismissDate
            // 
            this.dtDismissDate.Enabled = false;
            this.dtDismissDate.Location = new System.Drawing.Point(17, 372);
            this.dtDismissDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDismissDate.Name = "dtDismissDate";
            this.dtDismissDate.Size = new System.Drawing.Size(151, 20);
            this.dtDismissDate.TabIndex = 13;
            // 
            // labDismissReason
            // 
            this.labDismissReason.Enabled = false;
            this.labDismissReason.Location = new System.Drawing.Point(178, 321);
            this.labDismissReason.Name = "labDismissReason";
            this.labDismissReason.Size = new System.Drawing.Size(293, 16);
            this.labDismissReason.TabIndex = 29;
            this.labDismissReason.Text = "Причина увольнения";
            // 
            // tbDismissReason
            // 
            this.tbDismissReason.Enabled = false;
            this.tbDismissReason.Location = new System.Drawing.Point(178, 340);
            this.tbDismissReason.Multiline = true;
            this.tbDismissReason.Name = "tbDismissReason";
            this.tbDismissReason.Size = new System.Drawing.Size(293, 52);
            this.tbDismissReason.TabIndex = 14;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(20, 417);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(117, 25);
            this.butSave.TabIndex = 15;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(178, 417);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(117, 25);
            this.butCancel.TabIndex = 16;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // cbDismiss
            // 
            this.cbDismiss.Location = new System.Drawing.Point(20, 324);
            this.cbDismiss.Name = "cbDismiss";
            this.cbDismiss.Size = new System.Drawing.Size(146, 16);
            this.cbDismiss.TabIndex = 12;
            this.cbDismiss.Text = "Уволить";
            this.cbDismiss.UseVisualStyleBackColor = true;
            this.cbDismiss.CheckedChanged += new System.EventHandler(this.cbDismiss_CheckedChanged);
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.Enabled = false;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.ItemHeight = 13;
            this.cbDepartment.Location = new System.Drawing.Point(178, 227);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(293, 21);
            this.cbDepartment.TabIndex = 26;
            // 
            // labDepartment
            // 
            this.labDepartment.Enabled = false;
            this.labDepartment.Location = new System.Drawing.Point(178, 208);
            this.labDepartment.Name = "labDepartment";
            this.labDepartment.Size = new System.Drawing.Size(293, 16);
            this.labDepartment.TabIndex = 26;
            this.labDepartment.Text = "Подразделение";
            // 
            // tbPosition
            // 
            this.tbPosition.Enabled = false;
            this.tbPosition.Location = new System.Drawing.Point(15, 282);
            this.tbPosition.MaxLength = 256;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(456, 20);
            this.tbPosition.TabIndex = 11;
            // 
            // labPosition
            // 
            this.labPosition.Enabled = false;
            this.labPosition.Location = new System.Drawing.Point(15, 264);
            this.labPosition.Name = "labPosition";
            this.labPosition.Size = new System.Drawing.Size(456, 15);
            this.labPosition.TabIndex = 27;
            this.labPosition.Text = "Должность";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 461);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.labPosition);
            this.Controls.Add(this.labDepartment);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.cbDismiss);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.labDismissReason);
            this.Controls.Add(this.tbDismissReason);
            this.Controls.Add(this.labDismissDate);
            this.Controls.Add(this.dtDismissDate);
            this.Controls.Add(this.labEmployDate);
            this.Controls.Add(this.dtEmployDate);
            this.Controls.Add(this.tbTaxNumber);
            this.Controls.Add(this.labTaxNumber);
            this.Controls.Add(this.labBirthPlace);
            this.Controls.Add(this.tbBirthPlace);
            this.Controls.Add(this.labBirthDay);
            this.Controls.Add(this.dtBirthDay);
            this.Controls.Add(this.rbGenderFemale);
            this.Controls.Add(this.rbGenderMale);
            this.Controls.Add(this.labGender);
            this.Controls.Add(this.tbMiddleName);
            this.Controls.Add(this.labMiddleName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.labFirstName);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.labLastName);
            this.Controls.Add(this.tbPersonNumber);
            this.Controls.Add(this.labPersonNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EmployeeForm";
            this.Text = "Карточка сотрудника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPersonNumber;
        private System.Windows.Forms.TextBox tbPersonNumber;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label labLastName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label labFirstName;
        private System.Windows.Forms.TextBox tbMiddleName;
        private System.Windows.Forms.Label labMiddleName;
        private System.Windows.Forms.Label labGender;
        private System.Windows.Forms.RadioButton rbGenderMale;
        private System.Windows.Forms.RadioButton rbGenderFemale;
        private System.Windows.Forms.DateTimePicker dtBirthDay;
        private System.Windows.Forms.Label labBirthDay;
        private System.Windows.Forms.TextBox tbBirthPlace;
        private System.Windows.Forms.Label labBirthPlace;
        private System.Windows.Forms.TextBox tbTaxNumber;
        private System.Windows.Forms.Label labTaxNumber;
        private System.Windows.Forms.Label labEmployDate;
        private System.Windows.Forms.DateTimePicker dtEmployDate;
        private System.Windows.Forms.Label labDismissDate;
        private System.Windows.Forms.DateTimePicker dtDismissDate;
        private System.Windows.Forms.Label labDismissReason;
        private System.Windows.Forms.TextBox tbDismissReason;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.CheckBox cbDismiss;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label labDepartment;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.Label labPosition;
    }
}