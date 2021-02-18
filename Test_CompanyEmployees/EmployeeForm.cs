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
    public partial class EmployeeForm : Form
    {
        public struct DATA
        {
            public string sPersonelNumber;
            public string sTaxNumber;
            public string sFirstName;
            public string sMiddleName;
            public string sLastName;
            public ModelEmployees.GenderName gender;
            public DateTime dtBirthDay;
            public string sBirthPlace;
            public DateTime dtEmployDay;
            public List<string> listDepartments;
            public List<int> listDepartIDs;
            public string sDepartment;
            public int iDepartID;
            public string sPosition;
            public DateTime dtDismisDay;
            public string sDismisReason;
            public bool bDismissal;
        }

        public EmployeeForm(List<string> listDepartsName, List<int> listDepartsIDs)
        {
            InitializeComponent();

            cbDepartment.Items.AddRange(listDepartsName.ToArray());
            listDepartIDs =listDepartsIDs;

            KeyDown += EmployeeForm_KeyDown;
            dtEmployDate.Value = DateTime.Today;
            dtBirthDay.Value = dtBirthDay.MinDate;
            dtDismissDate.Value = dtDismissDate.MinDate;

            EnableItems(false);
        }

        public EmployeeForm(List<string> listDepartsName, List<int> listDepartsIDs, string sDepartment)
        {
            InitializeComponent();

            cbDepartment.Items.AddRange(listDepartsName.ToArray());
            cbDepartment.SelectedItem = sDepartment;
            listDepartIDs = listDepartsIDs;

            KeyDown += EmployeeForm_KeyDown;
            dtEmployDate.Value = DateTime.Today;
            dtBirthDay.Value = dtBirthDay.MinDate;
            dtDismissDate.Value = dtDismissDate.MinDate;

            EnableItems(false);
        }

        public EmployeeForm(DATA data)
        {
            InitializeComponent();

            KeyDown += EmployeeForm_KeyDown;
            tbPersonNumber.Text = data.sPersonelNumber.Trim();
            tbTaxNumber.Text = data.sTaxNumber.Trim();

            tbFirstName.Text = data.sFirstName.Trim();
            tbMiddleName.Text = data.sMiddleName.Trim();
            tbLastName.Text = data.sLastName.Trim();

            switch (data.gender)
            {
                case ModelEmployees.GenderName.FEMALE:
                    rbGenderFemale.Checked = true;
                    break;
                case ModelEmployees.GenderName.MALE:
                    rbGenderMale.Checked = true;
                    break;
            }

            dtBirthDay.Value = data.dtBirthDay;
            tbBirthPlace.Text = data.sBirthPlace.Trim();

            cbDepartment.Items.AddRange(data.listDepartments.ToArray());
            cbDepartment.SelectedItem = data.sDepartment;
            listDepartIDs = data.listDepartIDs;
            if (data.sPosition != null)
                tbPosition.Text = data.sPosition.Trim();

            dtEmployDate.Value = data.dtEmployDay;
            cbDismiss.CheckedChanged -= cbDismiss_CheckedChanged;
            cbDismiss.Checked = data.bDismissal;
            cbDismiss.CheckedChanged += cbDismiss_CheckedChanged;

            if (data.bDismissal)
            {
                dtDismissDate.Value = data.dtDismisDay;
                tbDismissReason.Text = data.sDismisReason.Trim();
            }
            else
                dtDismissDate.Value = dtDismissDate.MinDate;

            EnableItems(data.bDismissal);
        }

        private List<int> listDepartIDs = new List<int>();

        private void EmployeeForm_KeyDown(object sender, KeyEventArgs ea)
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

        private void SaveAndClose()
        {
            if (CheckForm())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void butCancel_Click(object sender, EventArgs ea)
        {
            Cancel();
        }

        private void butSave_Click(object sender, EventArgs ea)
        {
            SaveAndClose();
        }

        private bool CheckForm()
        {
            tbBirthPlace.Text = tbBirthPlace.Text.Trim();
            tbDismissReason.Text = tbDismissReason.Text.Trim();
            tbFirstName.Text = tbFirstName.Text.Trim();
            tbLastName.Text = tbLastName.Text.Trim();
            tbMiddleName.Text = tbMiddleName.Text.Trim();
            tbPersonNumber.Text = tbPersonNumber.Text.Trim();
            tbPosition.Text = tbPosition.Text.Trim();
            tbTaxNumber.Text = tbTaxNumber.Text.Trim();

            if (tbPersonNumber.Text.Length == 0 || tbTaxNumber.Text.Length == 0 ||
                tbLastName.Text.Length == 0 || tbFirstName.Text.Length == 0 || tbMiddleName.Text.Length == 0 ||
                tbBirthPlace.Text.Length == 0)
            {
                MessageBox.Show("Все доступные поля должны быть заполнены!", "Ошибка заполнения формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rbGenderMale.Checked && !rbGenderFemale.Checked)
            {
                MessageBox.Show("Укажите, пожалуйста, пол сотрудника ?", "Ошибка заполенния формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtBirthDay.Value == dtBirthDay.MinDate || dtBirthDay.Value.Date == DateTime.Today)
            {
                MessageBox.Show("Укажите, пожалуйста, день рождения сотрудника ?", "Ошибка заполнения формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(tbDismissReason.Enabled && tbDismissReason.Text.Length==0)
            {
                MessageBox.Show("Введите причину увольнения сотрудника либо отметите увольнение.", "Ошибка заполнения формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void cbDismiss_CheckedChanged(object sender, EventArgs ea)
        {
            if (cbDismiss.Checked)
            {
                if (MessageBox.Show(
                    "Вы действительно желаете уволить ценного сотрудника\r\n" +
                    $"{tbLastName.Text} {tbFirstName.Text} {tbMiddleName.Text} ?\r\n" +
                    "Если да, то выберите желаемую дату увольнения, введите причину и нажмите кнопку \"Сохранить\".",
                    "Увольнение сотрудника",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtDismissDate.Value = DateTime.Today;
                    EnableItems(true);
                }
                else
                {
                    cbDismiss.CheckedChanged -= cbDismiss_CheckedChanged;
                    cbDismiss.Checked = false;
                    cbDismiss.CheckedChanged += cbDismiss_CheckedChanged;
                }
            }
            else
            {
                if (MessageBox.Show(
                    "Вы действительно желаете восстановить ценного сотрудника\r\n" +
                    $"{tbLastName.Text} {tbFirstName.Text} {tbMiddleName.Text} ?",
                    "Восстановление сотрудника",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtDismissDate.Value = dtDismissDate.MinDate;
                    tbDismissReason.Text = "";
                    EnableItems(false);
                }
                else
                {
                    cbDismiss.CheckedChanged -= cbDismiss_CheckedChanged;
                    cbDismiss.Checked = true;
                    cbDismiss.CheckedChanged += cbDismiss_CheckedChanged;
                }
            }
        }

        private void EnableItems(bool bIsDismiss)
        {
            labDismissDate.Enabled = bIsDismiss;
            dtDismissDate.Enabled = bIsDismiss;
            labDismissReason.Enabled = bIsDismiss;
            tbDismissReason.Enabled = bIsDismiss;

            labDepartment.Enabled = !bIsDismiss;
            cbDepartment.Enabled = !bIsDismiss;
            labPosition.Enabled = !bIsDismiss;
            tbPosition.Enabled = !bIsDismiss;
        }

        public DATA EmployeeData
        {
            get
            {
                DATA data = new DATA();

                data.sPersonelNumber = tbPersonNumber.Text;
                data.sTaxNumber = tbTaxNumber.Text;

                data.sFirstName = tbFirstName.Text;
                data.sMiddleName = tbMiddleName.Text;
                data.sLastName = tbLastName.Text;

                if (rbGenderFemale.Checked)
                    data.gender = ModelEmployees.GenderName.FEMALE;
                if (rbGenderMale.Checked)
                    data.gender = ModelEmployees.GenderName.MALE;

                data.dtBirthDay = dtBirthDay.Value;
                data.sBirthPlace = tbBirthPlace.Text;

                data.dtEmployDay = dtEmployDate.Value;
                data.sPosition = tbPosition.Text;
                data.sDepartment = cbDepartment.Text;

                if (cbDepartment.SelectedIndex >= 0 && cbDepartment.SelectedIndex < listDepartIDs.Count)
                    data.iDepartID = listDepartIDs[cbDepartment.SelectedIndex];
                else
                    data.iDepartID = -1;

                data.bDismissal = dtDismissDate.Value > dtDismissDate.MinDate;
                if (data.bDismissal)
                {
                    data.dtDismisDay = dtDismissDate.Value;
                    data.sDismisReason = tbDismissReason.Text;
                }

                return data;
            }
        }
    }
}
