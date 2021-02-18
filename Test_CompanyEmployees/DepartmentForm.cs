using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_CompanyEmployees
{
    public partial class DepartmentForm : Form
    {
        public DepartmentForm(string sName, string sParentName)
        {
            InitializeComponent();
            Initialize();
            tbDepartName.Text = sName;
            tbParentDepart.Text = sParentName;
        }

        private void Initialize()
        {
            KeyDown += DepartmentForm_KeyDown;
        }

        private void DepartmentForm_KeyDown(object sender, KeyEventArgs ea)
        {
            switch(ea.KeyCode)
            {
                case Keys.Enter:
                    SaveAndClose();
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
            }
        }

        private void butSave_Click(object sender, EventArgs ea)
        {
            SaveAndClose();
        }

        private void butCancel_Click(object sender, EventArgs ea)
        {
            Cancel();
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveAndClose()
        {
            tbDepartName.Text = tbDepartName.Text.Trim();
            if(tbDepartName.Text.Length==0)
            {
                MessageBox.Show("Название подразделения не может быть пустым", "Ошибка заполнения формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public string DepartmentName
        {
            get
            {
                return tbDepartName.Text;
            }
        }
    }
}
